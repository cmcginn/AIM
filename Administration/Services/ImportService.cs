using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AIM.Data;
using AIM.Administration.Models;
using AIM.Administration.Models.ViewModels;
using AIM.Common.Types;
using AIM.Common.Types.AllClients;
using AIM.Workflows.FileUpload;
using AIM.Common.Services;
using LINQtoCSV;
using System.Activities;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using AIM.Workflows;
namespace AIM.Administration.Services
{
    public interface IImportService
    {
        CsvFileInfo GetCsvColumns(ImportForm file);
        XmlImportInfo TransformToXml(CsvFileInfo csvFileInfo, List<FieldMap> fieldMaps);
        bool ImportSingleContact(Guid clientId, AllClientsContact contact, Enumerations.WebformType webformType);
    }

    public class ImportService : IImportService
    {
        private FileService _fileService;
        private XmlRepository _xmlRepository;

        public ImportService()
        {

        }
        public bool ImportSingleContact(Guid clientId, AllClientsContact contact, Enumerations.WebformType webformType)
        {
            bool result = false;
            using (var ctx = new DomainContext())
            {
                var allClientsContactExport = new AllClientsContactExport { Contact = contact };
                var client = ctx.Client.Single(n => n.Id == clientId);
                allClientsContactExport.Account = AllClientsService.GetAllClientsAccount(client);
                var webForms = AllClientsService.GetAllClientsWebforms(allClientsContactExport.Account);
                allClientsContactExport.AllClientsWebform = webForms.Single(n => n.WebformType == webformType);
                result = AllClientsService.ExportContact(allClientsContactExport).Contains("lblThankYou");
            }
            return result;
        }
        public ImportService(XmlRepository xmlRepository)
        {
            _fileService = new FileService();
            _xmlRepository = xmlRepository;
        }

        public CsvFileInfo GetCsvColumns(ImportForm file)
        {
            string path;

            try
            {
                //path = _fileService.Save(file.File, "App_Data\\uploads");
                path = _fileService.Save(file.File);
            }
            catch (Exception e)
            {

                throw e;
            }
            var skip = file.FirstRowContainsColumnHeadings ? 1 : 0;
            var rawRows = GetRawRows(path);
            var dataRow = rawRows.First();
            return new CsvFileInfo
            {
                Name = Path.GetFileName(path),
                Path = path,
                Columns = dataRow.Select((t, i) => new CsvColumn
                {
                    Id = i,
                    Name = t.Value
                }).ToList(),
                Category = file.Category,
                Flag = file.Flag
            };
        }
        public void ImportWorkflow(FileInfo importFile, XmlImportInfo importInfo)
        {
            var accountModel = System.Web.HttpContext.Current.Session["allClientsAccountModel"] as AllClientsAccountModel;

            if (accountModel != null)
            {
                var results = WorkflowInvoker.Invoke(new ClientFileImportActivity(),
                                       new Dictionary<string, object> { { "clientId", accountModel.ClientId }, { "importFile", importFile } });
                int importCount = 0;
                int failureCount = 0;
                int.TryParse(results["importCountArg"].ToString(), out importCount);
                int.TryParse(results["ImportFailureArg"].ToString(), out failureCount);
                importInfo.SuccessCount = importCount;
                importInfo.FailureCount = failureCount;
            }
        }

        public XmlImportInfo TransformToXml(CsvFileInfo csvFileInfo, List<FieldMap> fieldMaps)
        {

            string csvFilePath = csvFileInfo.Path;
            var rawRows = GetRawRows(csvFilePath).Skip(csvFileInfo.FirstRowContainsColumnHeadings ? 1 : 0);
            var category = _xmlRepository.GetCategory(csvFileInfo.Category);
            var flag = _xmlRepository.GetFlag(csvFileInfo.Flag);

            var rowsToContacts = ConvertRowsToContacts(rawRows, fieldMaps, category, flag);

            var xmlFilePath = csvFilePath.Replace(Path.GetExtension(csvFilePath), ".xml");
            XmlImportInfo importResult = null;
            try
            {
                GenerateXml(rowsToContacts.Contacts, xmlFilePath);
                using (DomainContext ctx = new DomainContext())
                {
                    var account = System.Web.HttpContext.Current.Session["allClientsAccountModel"] as AllClientsAccountModel;
                    var importRecord = new ClientFileImport();
                    importRecord.Id = Guid.NewGuid();
                    importRecord.ImportedFilePath = xmlFilePath;
                    importRecord.UploadFilePath = csvFileInfo.Path;
                    importRecord.RecordsImported = rowsToContacts.SuccessCount;
                    importRecord.RecordsFailed = rowsToContacts.FailureCount;
                    importRecord.ClientId = account.ClientId;
                    importRecord.LastUpdated = System.DateTime.Now;
                    ctx.ClientFileImport.InsertOnSubmit(importRecord);
                    ctx.SubmitChanges();
                }
                var importFile = new FileInfo(xmlFilePath);
                importResult = new XmlImportInfo { SuccessCount = rowsToContacts.SuccessCount, FailureCount = rowsToContacts.FailureCount, DuplicateCount = rowsToContacts.DuplicateCount, FileName = Path.GetFileName(xmlFilePath) };
                ImportWorkflow(importFile, importResult);
            }
            catch (Exception e)
            {
                throw e;
            }
            return importResult;
        }
        private static string GetFieldMapValue(DataRow row, IEnumerable<FieldMap> fieldMaps, string key)
        {
            string result = String.Empty;
            var fieldMapKey = fieldMaps.SingleOrDefault(x => x.FieldName == key);
            if (fieldMapKey != null)
                result = row[fieldMapKey.ColumnId].Value;
            return result;
        }
        private static ConversionResult ConvertRowsToContacts(IEnumerable<DataRow> rawRows, IEnumerable<FieldMap> fieldMaps, Category category, Flag flag)
        {
            int successCount = 0, failureCount = 0, duplicateCount = 0;

            var contacts = new List<AllClientsContact>();
            foreach (var rawRow in rawRows)
            {
                var contact = new AllClientsContact();
                contact.FirstName = GetFieldMapValue(rawRow, fieldMaps, "FirstName");
                contact.LastName = GetFieldMapValue(rawRow, fieldMaps, "LastName");
                contact.City = GetFieldMapValue(rawRow, fieldMaps, "City");
                contact.State = GetFieldMapValue(rawRow, fieldMaps, "State");
                contact.Zip = GetFieldMapValue(rawRow, fieldMaps, "Zip");
                contact.Email = GetFieldMapValue(rawRow, fieldMaps, "Email");
                contact.Company = GetFieldMapValue(rawRow, fieldMaps, "Company");
                contact.Phone = GetFieldMapValue(rawRow, fieldMaps, "Phone");
                contact.Categories.Add(category);

                contact.Custom = new List<CustomElement>();
                var birthDate = new CustomElement { Name = "Birthday", Value = GetFieldMapValue(rawRow, fieldMaps, "Birthday") };
                contact.Custom.Add(birthDate);
                contact.Flags.Add(flag);

                if (!contact.IsValid())
                {
                    failureCount++;
                    continue;
                }
                if (contacts.Where(x => x.Email == contact.Email).Count() != 0)
                {
                    duplicateCount++;
                    continue;
                }
                successCount++;
                contacts.Add(contact);
            }
            return new ConversionResult { SuccessCount = successCount, FailureCount = failureCount, DuplicateCount = duplicateCount, Contacts = contacts };
        }


        private IEnumerable<DataRow> GetRawRows(string csvFilePath)
        {
            return GetRawRows(csvFilePath, false);
        }
        private IEnumerable<DataRow> GetRawRows(string csvFilePath, bool firstLineHasColumns)
        {
            var cc = new CsvContext();
            var result = cc.Read<DataRow>(csvFilePath, new CsvFileDescription { SeparatorChar = ',', FirstLineHasColumnNames = false });
            return result;
        }
        private void GenerateXml(List<AllClientsContact> contacts, string xmlFilePath)
        {
            var ser = new XmlSerializer(contacts.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            ns.Add("", "");
            var fs = File.Open(
                   xmlFilePath,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.ReadWrite);
            ser.Serialize(fs, contacts);
            fs.Close();
        }
    }

    internal class ConversionResult
    {
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public int DuplicateCount { get; set; }
        public List<AllClientsContact> Contacts { get; set; }
    }

    public class XmlImportInfo
    {
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public int DuplicateCount { get; set; }
        public string FileName { get; set; }
    }
}