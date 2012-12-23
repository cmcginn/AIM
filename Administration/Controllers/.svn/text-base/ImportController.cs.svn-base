using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AIM.Data;
using AIM.Administration.Models.ViewModels;
using AIM.Administration.Services;
using AIM.Administration.Models;
using AIM.Common.Types.AllClients;
using AIM.Common.Services;
using AIM.Common.Types;
using AIM.Administration.Infrastructure;

namespace AIM.Administration.Controllers
{
    [Authorize( Users = "AllClientsUsers" )]
    public class ImportController : ApplicationController
    {
        private ImportService _importService;
        private XmlRepository _xmlRepository;
  

        public ImportController()
        {
            string fileName = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/App_Data"), "LookUps.xml");
            _xmlRepository = new XmlRepository(fileName);
            _importService = new ImportService(_xmlRepository);
        
        }
        public ActionResult Index()
        {
            GetAccount();
            try
            {
                ViewBag.Categories = _xmlRepository.GetAllCategories();
                ViewBag.Flags = _xmlRepository.GetAllFlags();
            }
            catch (Exception)
            {
                AddError("Could not get list of categories and flags");
                return View();
            }
            return View();
        }

        [HttpPost]
        [FormValueRequired(new string[]{"file"})]
        public ActionResult Index(ImportForm importForm)
        {
            GetAccount();
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _xmlRepository.GetAllCategories();
                //ViewBag.Flags = _xmlRepository.GetAllFlags();
                return View();
                //return RedirectToAction("Index");
            }
            try
            {
                CsvFileInfo csvFileInfo = _importService.GetCsvColumns(importForm);
                csvFileInfo.FirstRowContainsColumnHeadings = importForm.FirstRowContainsColumnHeadings;
                TempData["CsvFileInfo"] = csvFileInfo;
                
                List<SelectListItem> selectListItems = GetFields();

                return View("ImportMap", new FieldMapperViewModel
                {
                    ColumnMaps = csvFileInfo.Columns,
                    Fields = selectListItems
                });
            }
            catch (Exception)
            {
                AddError("There is an error with importing CSV file,Please try again later.");
                return RedirectToAction("Index");
            }
        }

        private List<SelectListItem> GetFields()
        {
            var propertyInfos = typeof(AllClientsContact).GetProperties().Where(x => x.Name != "Flags" && x.Name !="Categories");

            List<SelectListItem> selectListItems = propertyInfos
                .Select(propertyInfo => new SelectListItem { Text = propertyInfo.Name, Value = propertyInfo.Name }).
                ToList();
            selectListItems.Add(new SelectListItem { Text = "Birthday", Value = "Birthday" });
            selectListItems.Add(new SelectListItem { Text = "(Skip this field)", Value = "Skip" });
            
            return selectListItems;
        }

        [HttpPost]
        [FormValueRequired(new string[] { "single" })]
        [ActionName("Index")]
        public ActionResult SingleContactImport(AllClientsContact contact)
        {
            
            ViewBag.Categories = _xmlRepository.GetAllCategories();
            //ViewBag.Flags = _xmlRepository.GetAllFlags();
            if (!String.IsNullOrEmpty(Request.Form["Birthday"].ToString()))
            {
                var bday = DateTime.Now;
                if (!DateTime.TryParse(Request.Form["Birthday"].ToString(), out bday))
                {
                    ViewData.Add("SingleImportError", "Please ensure Birthday is in the format MM/DD/YYYY");
                    return View();
                }
                else
                {
                    contact.Custom = new List<CustomElement> { new CustomElement { Name = "Birthday", Value = bday.ToShortDateString() } };
                }
            }
            
            
            var category = Request.Form["Category"].Split(',')[1];
            
            if (!contact.IsValid() || category == "")
            {
                ViewData.Add("SingleImportError", "Please ensure the category, first name, last name, and email are filled out.");
            }
            else
            {
                
                ViewData.Add("ImportResult", 1);
                var webFormType = (Enumerations.WebformType)Enum.Parse(typeof(Enumerations.WebformType),category);

                var importer = new ImportService();
                var result = importer.ImportSingleContact(Account.ClientId, contact, webFormType);
                if (result)
                    ViewData["ImportResult"] = 0;
               
            }
            return View();
        }

        [HttpPost]
        public ActionResult ImportMap(List<FieldMap> fieldMaps)
        {
            if (TempData.ContainsKey("error"))
                TempData["error"] = String.Empty;
          
            if (TempData.Keys.Contains("CsvFileInfo"))
            {
                var csvFileInfo = (CsvFileInfo)TempData["CsvFileInfo"];
                bool any =
                fieldMaps.GroupBy(x => x.FieldName).Select(y => new { key = y.Key, count = y.Count() }).Where(w => w.key != "Skip").Any(
                    z => z.count > 1);

                if (any)
                {
                    AddError("Please note that you can not map same field to more than one column");
                    TempData["CsvFileInfo"] = csvFileInfo;
                    List<SelectListItem> selectListItems = GetFields();
                    return View("ImportMap", new FieldMapperViewModel
                                                 {                                                     
                                                     ColumnMaps = csvFileInfo.Columns,
                                                     Fields = selectListItems
                                                 });
                    
                }

                XmlImportInfo xmlImportInfo;

                  var accountModel = Session["allClientsAccountModel"] as AllClientsAccountModel;
     
                  
                    xmlImportInfo = _importService.TransformToXml(csvFileInfo, fieldMaps);

                return View("ImportResult", xmlImportInfo);
            }
            AddError("Please import a CSV file form Import Contacts Section");
            return RedirectToAction("Index");
        }



        public ActionResult Download(string id)
        {
            string existpath = Path.Combine(ConfigurationManager.AppSettings["UploadPath"], id);
            var file = new FileInfo(existpath);
            if (file.Exists)
            {
                return File(existpath, "text/xml", id);
            }
            return RedirectToAction("Index");
        }
    }
}
