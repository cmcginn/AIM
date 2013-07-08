using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public static XElement GetTestData()
        {
            var testDataFile = XElement.Load(System.Configuration.ConfigurationManager.AppSettings["MBTestData"]);
            return testDataFile;
        }
        public static XElement SelectServiceRequest(MindBodyAccount account,string selectStatement)
        {
            bool testMode = false;
            if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("TestMode"))
                bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["TestMode"], out testMode);
            if (testMode)
                return GetTestData();

            int siteIdTest = 0;
            if (!int.TryParse(account.StudioID, out siteIdTest))
                throw new AIMException("Could not parse SiteID");
            var wr = WebRequest.Create("https://api.mindbodyonline.com/0_5/DataService.asmx");
            wr.Method = "POST";
            var aimServiceConfiguration = CommonService.GetServiceConfiguration();
            
            var msg = String.Format("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><SelectDataXml xmlns=\"http://clients.mindbodyonline.com/api/0_5\"><Request><SourceCredentials><SourceName>{0}</SourceName><Password>{1}</Password><SiteIDs><int>{2}</int></SiteIDs></SourceCredentials><XMLDetail>Full</XMLDetail><PageSize xsi:nil=\"true\"/><CurrentPageIndex>0</CurrentPageIndex><SelectSql>{3}</SelectSql></Request></SelectDataXml></s:Body></s:Envelope>", aimServiceConfiguration.ServiceConfiguration.MindBodySourceName, aimServiceConfiguration.ServiceConfiguration.MindBodyApiKey, siteIdTest,selectStatement);
            wr.ContentLength = msg.Length;
            wr.ContentType = "text/xml; charset=utf-8";
            wr.Headers.Add("SOAPAction", "http://clients.mindbodyonline.com/api/0_5/SelectDataXml");
            Stream dataStream = wr.GetRequestStream();
            var byteArray = new byte[msg.Length];
            dataStream.Write(msg.ToCharArray().Select(x => (byte)x).ToArray(), 0, byteArray.Length);
            dataStream.Close();
            WebResponse wresp = wr.GetResponse();
            var bb = new byte[wresp.ContentLength];
            var responseStream = wresp.GetResponseStream();
            var reader = new StreamReader(responseStream);
            string responseFromServer = reader.ReadToEnd();
            var elem = XElement.Parse(responseFromServer);
            var result = elem.Descendants("{http://clients.mindbodyonline.com/api/0_5}Results").First();
            return result;
        }
       

        public static List<AllClientsContact> MapToAllClientsContacts(XElement responseElement)
        {
            Contract.Requires(responseElement != null);
            
            List<AllClientsContact> result = new List<AllClientsContact>();
            FileInfo info = new FileInfo(String.Format("{0}{1}", Properties.Settings.Default.XslPath, "mbo-contact.xslt"));
            responseElement.Descendants("{http://clients.mindbodyonline.com/api/0_5}Row").ToList().ForEach(n =>
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
            var signupElement = row.Element("{http://clients.mindbodyonline.com/api/0_5}SignupDate") as XElement;
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
            Contract.Requires(importResponse.Name == "{http://clients.mindbodyonline.com/api/0_5}Row");
            
            AllClientsContactExport result = null;
            try
            {
                bool inactive = importResponse.Element("{http://clients.mindbodyonline.com/api/0_5}Inactive").Value == "True";
                bool prospect = importResponse.Element("{http://clients.mindbodyonline.com/api/0_5}IsProspect").Value == "True";
                string email = importResponse.Element("{http://clients.mindbodyonline.com/api/0_5}EmailName").Value.ToLower();
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
        public static AllClientsContactExport MapExportForAppointments(AllClientsContact contact, AllClientsAccount account, IClient client, List<AllClientsWebform> webforms)
        {
            var clientNotificationWebform = webforms.FirstOrDefault(x => x.WebformType == Types.Enumerations.WebformType.AppointmentReminder);
            var ownerNotificationWebForm = webforms.FirstOrDefault(x => x.WebformType == Types.Enumerations.WebformType.AutoNotification);
            if (clientNotificationWebform == null || ownerNotificationWebForm == null)
                return null;

            var apptDateTimeProperty = contact.Custom.SingleOrDefault(x => x.Name == "ApptDate");
            var apptTimeProperty = contact.Custom.SingleOrDefault(x => x.Name == "ClassTime");
            if (apptDateTimeProperty == null || apptTimeProperty == null)
                return null;
            
            var apptDate = System.DateTime.MinValue;
            var apptTime = System.DateTime.MinValue;
        
            if(!DateTime.TryParse(apptDateTimeProperty.Value,out apptDate))
                return null;

            if (!DateTime.TryParse(apptTimeProperty.Value, out apptTime))
                return null;
            apptDate = DateTime.Parse(String.Format("{0} {1}", apptDate.Date.ToShortDateString(), apptTime.TimeOfDay.ToString()));

            var result = new AllClientsContactExport
            {
                Account = account,
                Contact = contact
            };
            contact.Custom.Single(x => x.Name == "ApptDate").Value = apptDate.ToString();
            var comment = AllClientsService.GetAppointmentNotificationComments(contact);
            contact.Custom.Add(new CustomElement { Name = "Comments", Value = comment });

           
            //logic to determine action 
            //if appointment has passed
            if (apptDate.AddDays(Properties.Settings.Default.OwnerNotificationDateRange).Date == System.DateTime.Now.Date)
                result.AllClientsWebform = ownerNotificationWebForm;
                //if the appointment date is tomorrow
            else if (apptDate.Date == System.DateTime.Now.Date.AddDays(Properties.Settings.Default.ClientNotificationDateRange).Date)
                result.AllClientsWebform = clientNotificationWebform;
           
            return result;

        }
        public static List<IClient> GetActiveClients()
        {
            var aimServiceConfiguration =
              System.Configuration.ConfigurationManager.GetSection("aimServiceConfigurationGroup/aimServiceConfiguration") as
              AIMServiceConfigurationSection;
            List<IClient> result = null;
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager cmgr = new ClientManager(mgr);
                if(aimServiceConfiguration.ServiceConfiguration.TestClientId != Guid.Empty)
                    result = cmgr.GetActive().Where(n => n.ImportType.TypeName == IMPORT_TYPE && n.Id == aimServiceConfiguration.ServiceConfiguration.TestClientId).OfType<IClient>().ToList();
                else
                    result = cmgr.GetActive().Where(n => n.ImportType.TypeName == IMPORT_TYPE).OfType<IClient>().ToList();
               
                
            }
          
            return result.ToList();
        }
        /// <summary>
        /// Assigns unique instance based on email representing latest creation date time
        /// </summary>
        /// <param name="responseElement"></param>
        /// <returns></returns>
        public static XElement GetAppointmentNotifications(XElement responseElement)
        {
            
            var result = new XElement("{http://clients.mindbodyonline.com/api/0_5}Results");
            responseElement.Descendants("{http://clients.mindbodyonline.com/api/0_5}Row").GroupBy(x =>
                {
                    var xElement = x.Element("{http://clients.mindbodyonline.com/api/0_5}EmailName");
                    return xElement != null ? xElement.Value : null;
                }).ToList().ForEach(email =>
                {
                    DateTime testDt;
                    //select the row with the most recent Creation Date Time or default value 
                    //then the most recent ApptDate/ClassTime as a single DateTime
                    //where valid. This would be the most recent appointment
                    var latest = email.Select(x =>
                    new
                    {
                        Row = x,
                        ApptDate = x.Element("{http://clients.mindbodyonline.com/api/0_5}ApptDate") ?? new XElement("{http://clients.mindbodyonline.com/api/0_5}ApptDate", System.DateTime.MinValue),
                        ApptTime = x.Element("{http://clients.mindbodyonline.com/api/0_5}ClassTime") ?? new XElement("{http://clients.mindbodyonline.com/api/0_5}ClassTime", System.DateTime.MinValue),
                        CreationDate = x.Element("{http://clients.mindbodyonline.com/api/0_5}CreationDateTime") ?? new XElement("{http://clients.mindbodyonline.com/api/0_5}CreationDateTime", System.DateTime.MinValue)
                    })
                    .Where(z => DateTime.TryParse(z.ApptDate.Value, out testDt) && DateTime.TryParse(z.ApptTime.Value, out testDt))
                    .Select(a => new
                    {
                        Row = a.Row,

                        ApptDate = DateTime.Parse(String.Format("{0} {1}", DateTime.Parse(a.ApptDate.Value).ToString("MM/dd/yyyy"), DateTime.Parse(a.ApptTime.Value).ToString("hh:mm:ss"))),
                        CreationDateTime = DateTime.TryParse(a.CreationDate.Value, out testDt) ? DateTime.Parse(a.CreationDate.Value) : System.DateTime.MinValue
                    }).Distinct().GroupBy(x => x.CreationDateTime)
                    .OrderByDescending(x => x.Key);

                    result.Add(latest.First().Select(x=>x.Row));

                });
            return result;

        }
    }
}
