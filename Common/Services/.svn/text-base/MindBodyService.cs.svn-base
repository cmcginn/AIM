using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIM.Common.Types.AllClients;
using AIM.Common.Types.MindBody;
using System.Xml.Linq;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Diagnostics.Contracts;
using AIM.Data;
namespace AIM.Common.Services
{
    public class MindBodyService
    {
        public const string IMPORT_TYPE = "Mind Body Online";
        public const string MIND_BODY_SELECT_SERVICE_URL = "http://clients.mindbodyonline.com/api/0_4/SelectService.asmx/SelectData";
        public static XElement SelectServiceRequest(MindBodyAccount account)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["MBTestData"] != null)
            {
                return XElement.Load(System.Configuration.ConfigurationManager.AppSettings["MBTestData"]);                 

            }
            Contract.Requires(!String.IsNullOrEmpty(account.Password));
            Contract.Requires(!String.IsNullOrEmpty(account.Sourcename));
            Contract.Requires(!String.IsNullOrEmpty(account.StudioID));
            XElement response = null;
            string messageResponse = String.Empty;
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("Sourcename", account.Sourcename.Trim());
                parameters.Add("StudioID", account.StudioID.Trim());
                parameters.Add("Password", account.Password.Trim());
                parameters.Add("SelectSQL", "SELECT * FROM CLIENTS WHERE EMAILNAME IS NOT NULL AND SUSPENDED = 0 AND DELETED = 0 ORDER BY ClientID DESC");
                messageResponse = CommonService.HttpRequest(MIND_BODY_SELECT_SERVICE_URL, parameters);
                response = XElement.Parse(messageResponse);
            }
            catch (System.Exception ex)
            {
                throw new MessagingException("Invalid response while attempting message to MindBodyOnline", ex, "SELECT * FROM CLIENTS WHERE EMAILNAME IS NOT NULL AND SUSPENDED = 0 ",messageResponse.Substring(0,100));
            }
            return response;

        }

        public static List<AllClientsContact> MapToAllClientsContacts(XElement responseElement)
        {
            Contract.Requires(responseElement != null);
            
            List<AllClientsContact> result = new List<AllClientsContact>();
            FileInfo info = new FileInfo(String.Format("{0}{1}", Properties.Settings.Default.XslPath, "mbo-contact.xslt"));
            responseElement.Descendants("{http://clients.mindbodyonline.com/API/0_4}Row").ToList().ForEach(n =>
                {
                    XElement transformation = CommonService.Transform(n, info);
                    AllClientsContact deserializedObject = CommonService.FromXml(typeof(AllClientsContact), transformation.ToString()) as AllClientsContact;
                    if (deserializedObject != null)
                    {
                        //Prevent duplicates
                        if(result.Where(x=>x.Email == deserializedObject.Email).Count() == 0)
                            result.Add(deserializedObject);
                    }
                });

            return result;
        }

        public static AllClientsContact MapToAllClientsContact(XElement rowElement)
        {

            Contract.Requires(rowElement != null);
            Contract.Ensures(Contract.Result<AllClientsContact>() != null);
            AllClientsContact result = null;
            FileInfo info = new FileInfo(String.Format("{0}{1}", Properties.Settings.Default.XslPath, "mbo-contact.xslt"));
            XElement transformation = CommonService.Transform(rowElement, info);            
            AllClientsService.MapBirthdate(transformation);
            result = CommonService.FromXml(typeof(AllClientsContact), transformation.ToString()) as AllClientsContact;            
            return result;

        }

        public static MindBodyAccount GetMindBodyAccount(IClient client)
        {
            MindBodyAccount result = null;
            try
            {
                result = new MindBodyAccount();
                result.StudioID = client.ClientParameters.Element("StudioID").Value;
                result.Sourcename = client.ClientParameters.Element("Sourcename").Value;
                result.Password = client.ClientParameters.Element("Password").Value;
            }
            catch (System.Exception ex)
            {
                throw new AccountSetupException("Could not create valid AllClients account", ex, client);
            }
            return result;
        }
        static bool IsNew(XElement row)
        {
            bool result = false;
            var signupElement = row.Element("{http://clients.mindbodyonline.com/API/0_4}SignupDate") as XElement;
            if (signupElement != null)
            {
                if (!String.IsNullOrEmpty(signupElement.Value))
                {
                    DateTime signUpDate = System.DateTime.MinValue;
                    if (DateTime.TryParse(signupElement.Value, out signUpDate))
                    {
                        int days = (System.DateTime.Now - signUpDate).Days;
                        if (days < 31)
                            result = true;
                    }
                }
            }
            return result;
        }
        public static AllClientsContactExport MapExport(List<AllClientsContact> existingContacts, AllClientsAccount account, IClient client, List<AllClientsWebform> webforms, XElement importResponse)
        {
            Contract.Requires(importResponse.Name == "{http://clients.mindbodyonline.com/API/0_4}Row");
            
            AllClientsContactExport result = null;
            try
            {
                bool inactive = importResponse.Element("{http://clients.mindbodyonline.com/API/0_4}Inactive").Value == "True";
                bool prospect = importResponse.Element("{http://clients.mindbodyonline.com/API/0_4}IsProspect").Value == "True";
                string email = importResponse.Element("{http://clients.mindbodyonline.com/API/0_4}EmailName").Value.ToLower();
                bool isinsert = existingContacts.Where(n => n.Email.ToLower() == email).Count() == 0;
                bool isNew = IsNew(importResponse);
                AllClientsContact contact = MapToAllClientsContact(importResponse);
                AllClientsContactExport export = new AllClientsContactExport();
                export.Contact = contact;
                export.Account = account;

                if (isinsert)
                {
                    if (isNew)
                    {
                        export.AllClientsWebform = webforms.Where(n => n.WebformType == Types.Enumerations.WebformType.NewCustomer).Single();
                    }
                    else if (prospect)
                    {
                        export.AllClientsWebform = webforms.Where(n => n.WebformType == Types.Enumerations.WebformType.Lead).Single();
                    }
                    else
                    {
                        if (inactive)
                            export.AllClientsWebform = webforms.Where(n => n.WebformType == Types.Enumerations.WebformType.InactiveCustomer).Single();
                        else
                            export.AllClientsWebform = webforms.Where(n => n.WebformType == Types.Enumerations.WebformType.ActiveCustomer).Single();

                    }
                    //if only inserting we only add when not found on allclients
                    
                }
                else if (client.EnableUpdates)
                {
                    //we are an update
                    //perform lookup
                    var matchList = existingContacts.Where(n => n.Email.ToLower() == email);
                    if (matchList.Count() > 0)
                    {
                        //we have a match
                        var match = matchList.First();
                        //if not a lead, and their current allclients account is marked as prospect, they qualify for lead to customer
                        if ((!prospect & !inactive) && (match.Flags.Count > 0) && (match.Flags.Where(n => n.Name == "Prospect/Lead").Count() > 0))
                        {
                            export.AllClientsWebform = webforms.Where(n => n.WebformType == Types.Enumerations.WebformType.LeadToCustomer).Single();
                        }
                        else
                        {
                            export.AllClientsWebform = new AllClientsWebform { Account = account, FormKey = "0", FormName = "Bypass", WebformType = Types.Enumerations.WebformType.None };
                        }
                    }

                }
                else
                {
                    export.AllClientsWebform = new AllClientsWebform { Account = account, FormKey = "0", FormName = "Bypass", WebformType = Types.Enumerations.WebformType.None };
                }
                result = export;
            }
            catch (System.Exception ex)
            {
                throw new AIMException(String.Format("Could not MapExport:{0}", importResponse), ex);
            }
            return result;
        }
        public static List<IClient> GetActiveClients()
        {
            List<IClient> result = null;
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager cmgr = new ClientManager(mgr);
                result = cmgr.GetActive().Where(n => n.ImportType.TypeName == IMPORT_TYPE).OfType<IClient>().ToList();
               
                
            }
            return result;
        }
    }
}
