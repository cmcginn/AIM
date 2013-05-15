using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIM.Common.Types;
using System.Xml.Linq;
using Common.Messaging.Http;
using AIM.Common.Types.AllClients;
using AIM.Data;
using System.Diagnostics.Contracts;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace AIM.Common.Services
{
    public class AllClientsService
    {

        public static XElement GetContacts(AllClientsAccount account)
        {
            XElement result = null;
            try
            {
                result = CommonService.AllClientsRequest("GetContacts.aspx", account.AccountId, account.APIKey);
            }
            catch (System.Exception ex)
            {
                throw new MessagingException("Failed to retrieve contacts from AllClients", ex, "GetContacts", String.Empty);
            }
            return result;
        }
        public static List<AllClientsWebform> GetAllClientsWebforms(AllClientsAccount account)
        {

            List<AllClientsWebform> result = new List<AllClientsWebform>();
            try
            {
                XElement webforms = CommonService.AllClientsRequest("GetWebforms.aspx", account.AccountId, account.APIKey);

                //standard form names
                string appointmentReminderFormName = "6. sys_action_assign_appt_reminder";
                string leadToCustomerFormName = "5. sys_action_import_lead to customer";
                string customerFormName = "4. sys_action_import_customer";
                string customerInactiveFormName = "2. sys_action_import_customer_inactive";
                string leadFormName = "3. sys_action_import_lead";
                string newCustomerFormName = "1. sys_action_import_customer_new";
                string aimsAutoNotificationFormName = "AIMS Auto Notification";
                //webforms from All Clients as Elements
                XElement leadToCustomerForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == leadToCustomerFormName).First();
                XElement customerForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == customerFormName).First();
                XElement customerInactiveForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == customerInactiveFormName).First();
                XElement leadForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == leadFormName).First();
                XElement newCustomerForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == newCustomerFormName).First();
                XElement aimsAutoNotificationForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == aimsAutoNotificationFormName).FirstOrDefault();
                XElement appointmentReminderForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == appointmentReminderFormName).FirstOrDefault();
                
                //Assign new forms with FormKeys
                AllClientsWebform leadToCustomerWebForm = new AllClientsWebform();
                leadToCustomerWebForm.WebformType = Enumerations.WebformType.LeadToCustomer;
                leadToCustomerWebForm.FormKey = leadToCustomerForm.Element("formkey").Value;

                AllClientsWebform customerWebform = new AllClientsWebform();
                customerWebform.WebformType = Enumerations.WebformType.ActiveCustomer;
                customerWebform.FormKey = customerForm.Element("formkey").Value;

                AllClientsWebform customerInactiveWebform = new AllClientsWebform();
                customerInactiveWebform.WebformType = Enumerations.WebformType.InactiveCustomer;
                customerInactiveWebform.FormKey = customerInactiveForm.Element("formkey").Value;

                AllClientsWebform customerLeadWebform = new AllClientsWebform();
                customerLeadWebform.WebformType = Enumerations.WebformType.Lead;
                customerLeadWebform.FormKey = leadForm.Element("formkey").Value;

                AllClientsWebform newCustomerWebform = new AllClientsWebform();
                newCustomerWebform.WebformType = Enumerations.WebformType.NewCustomer;
                newCustomerWebform.FormKey = newCustomerForm.Element("formkey").Value;

                if (aimsAutoNotificationForm != null)
                {
                    AllClientsWebform aimsAutoNotificationWebform = new AllClientsWebform();
                    aimsAutoNotificationWebform.WebformType = Enumerations.WebformType.AutoNotification;
                    aimsAutoNotificationWebform.FormKey = aimsAutoNotificationForm.Element("formkey").Value;
                    aimsAutoNotificationWebform.Account = account;
                    result.Add(aimsAutoNotificationWebform);
                }

                if (appointmentReminderForm != null)
                {
                    AllClientsWebform appointmentReminderWebForm = new AllClientsWebform();
                    appointmentReminderWebForm.WebformType = Enumerations.WebformType.AppointmentReminder;
                    appointmentReminderWebForm.FormKey = appointmentReminderForm.Element("formkey").Value;
                    appointmentReminderWebForm.Account = account;
                    result.Add(appointmentReminderWebForm);
                }
                //Assign Accounts 
                leadToCustomerWebForm.Account = account;
                customerWebform.Account = account;
                customerInactiveWebform.Account = account;
                customerLeadWebform.Account = account;
                newCustomerWebform.Account = account;
                //Assign FormName
                leadToCustomerWebForm.FormName = leadToCustomerFormName;
                customerWebform.FormName = customerFormName;
                customerInactiveWebform.FormName = customerInactiveFormName;
                customerLeadWebform.FormName = leadFormName;
                newCustomerWebform.FormName = newCustomerFormName;

                result.Add(leadToCustomerWebForm);
                result.Add(customerWebform);
                result.Add(customerInactiveWebform);
                result.Add(customerLeadWebform);
                result.Add(newCustomerWebform);
            }
            catch (System.Exception ex)
            {
                throw new AccountSetupException(String.Format("Could not retrieve expected webforms for client: {0}", account.ClientName), ex);
            }

            return result;

        }
        public static AllClientsAccount GetAllClientsAccount(IClient client)
        {
            AllClientsAccount result = null;
            try
            {
                result = new AllClientsAccount();
                result.AccountId = client.AccountId;
                result.APIKey = client.ApiKey;
                result.Active = client.Active;
                result.ClientName = client.Company;

            }
            catch (System.Exception ex)
            {
                throw new AccountSetupException("Could not create valid AllClients account", ex, client);
            }
            return result;
        }
        public static Dictionary<string, string> GetContactExportParameters(AllClientsContactExport export)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            XElement contactElement = CommonService.ToXml(typeof(AllClientsContact), export.Contact);
            MapBirthdate(contactElement);
            XElement flags = contactElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}Flags");
            XElement categories = contactElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}Categories");
            XElement custom = contactElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}Custom");
            IEnumerable<XElement> contact = contactElement.Elements().Except(flags.DescendantsAndSelf()).Except(categories.DescendantsAndSelf()).Except(custom.DescendantsAndSelf());
            contact.ToList().ForEach(n =>
            {
                if (n.Name.LocalName != "Categories" && n.Name.LocalName != "Flags" && n.Name.LocalName != "Custom" && n.Name.LocalName != "CustomElement")
                    result.Add(n.Name.LocalName.ToLower(), n.Value);
            });
            if (categories.Descendants().Count() > 0)
            {
                result.Add("category", categories.Elements().First().Element("{http://www.aimscrm.com/schema/2011/common/contact}Name").Value);
            }
            custom.Descendants().ToList().ForEach(customElement =>
                {
                    if (customElement.Elements("{http://www.aimscrm.com/schema/2011/common/contact}Value").Count() > 0)
                    {
                        result.Add(customElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}Name").Value.ToLower(), customElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}Value").Value);
                    }
                });

            result.Add("key", export.AllClientsWebform.FormKey);
            result.Add("accountid", export.Account.AccountId.ToString());
            result.Add("apikey", export.Account.APIKey);
            return result;
        }
        public static string ExportContact(AllClientsContactExport export)
        {
            Contract.ContractFailed += new EventHandler<ContractFailedEventArgs>(Contract_ContractFailed);
            Contract.Requires(export.Account.IsValid());
            Contract.Requires(export.AllClientsWebform.IsValid());
            Contract.Requires(export.Contact.IsValid());
            string result;
            var aimServiceConfiguration =
            System.Configuration.ConfigurationManager.GetSection("aimServiceConfigurationGroup/aimServiceConfiguration") as
            AIMServiceConfigurationSection;
            if (!aimServiceConfiguration.ServiceConfiguration.AllowExport)
                return "lblThankYou";
            XElement contactElement = CommonService.ToXml(typeof(AllClientsContact), export.Contact);
            Dictionary<string, string> parameters = GetContactExportParameters(export);
            XElement response = CommonService.AllClientsFormPost(parameters);
            //remove prospect tag if customer
            if (export.AllClientsWebform.WebformType != Enumerations.WebformType.Lead)
                AllClientsService.AddRemoveFlag(export.Account, true, export.Contact.Email, "Prospect/Lead");
            result = response.ToString();
            return result;


        }
        public static string GetAppointmentNotificationComments(AllClientsContact contact)
        {
            //TrainerFirst,TrainerLast,BookedLocation,TypeName,ClassTime,ApptDate
            string result = "";
            var trainerFirstElement = contact.Custom.FirstOrDefault(x => x.Name == "TrainerFirst");
            var trainerLastElement = contact.Custom.FirstOrDefault(x => x.Name == "TrainerLast");
            var bookedLocationElement = contact.Custom.FirstOrDefault(x => x.Name == "BookedLocation");
            var typeNameElement = contact.Custom.FirstOrDefault(x => x.Name == "TypeName");
            var classTimeElement = contact.Custom.FirstOrDefault(x => x.Name == "ClassTime");
            var apptDateElement = contact.Custom.FirstOrDefault(x => x.Name == "ApptDate");

            var trainerFirstVal = trainerFirstElement != null ? trainerFirstElement.Value : "Trainer first name not specified";
            var trainerLastVal = trainerLastElement != null ? trainerLastElement.Value : "Trainer last name not specified";
            var bookedLocationVal = bookedLocationElement != null ? bookedLocationElement.Value : "Location not specified";
            var typeNameVal = typeNameElement != null ? typeNameElement.Value : "Appointment type not specified";
            var classTimeVal = classTimeElement != null ? classTimeElement.Value : "Class Time Not Specified";
            var apptDateVal = apptDateElement != null ? apptDateElement.Value : "Appointment date/time not specified";

            var template = CommonSettings.AppointmentNotificationTemplate
                .Replace(@"\n", System.Environment.NewLine)
                .Replace("~TrainerFirst~", trainerFirstVal)
                .Replace("~TrainerLast~", trainerLastVal)
                .Replace("~BookedLocation~", bookedLocationVal)
                .Replace("~TypeName~", typeNameVal)
                .Replace("~ApptDate~", apptDateVal);
            return template;
        }
        //public static void ExportAppointmentNotification(AllClientsContactExport export, List<AllClientsWebform> webForms)
        //{
        //    try
        //    {
        //        var autoNotificationForm = webForms.FirstOrDefault(x => x.WebformType == Enumerations.WebformType.AutoNotification);
        //        if (autoNotificationForm == null)
        //            return;
        //        var appointmentReminderForm = webForms.FirstOrDefault(x => x.WebformType == Enumerations.WebformType.AppointmentReminder);
        //        if (appointmentReminderForm == null)
        //            return;
        //        //criteria for auo notification custom variables contains ApptDate
        //        var appointmentDate = export.Contact.Custom.FirstOrDefault(x => x.Name == "ApptDate");
        //        if (appointmentDate == null)
        //            return;
        //        //is the appointment date tommorrow?
        //        var testDate = System.DateTime.MinValue;
        //        if (!DateTime.TryParse(appointmentDate.Value, out testDate))
        //            return;
        //        AllClientsWebform notificationWebform = null;
        //        //appt tomorrow send  the email to client
        //        if (System.DateTime.Now.Date.AddDays(1).Date == testDate.Date)
        //            notificationWebform = appointmentReminderForm;
        //        else if (System.DateTime.Now.Date > testDate.Date && testDate > System.DateTime.Now.AddDays(-2))
        //            notificationWebform = autoNotificationForm;

        //        if (notificationWebform != null)
        //        {
        //            //we will clone a new contact export and send through traditional means
        //            var notifyExport = new AllClientsContactExport
        //            {
        //                Account = export.Account,
        //                AllClientsWebform = notificationWebform,
        //                Contact = export.Contact
        //            };

        //            notifyExport.Contact.Custom.Add(new CustomElement { Name = "Comments", Value = GetAppointmentNotificationComments(notifyExport.Contact) });
        //            ExportContact(notifyExport);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new AIMException("Could not create Auto Notification", ex);
        //    }


        //}
        static void Contract_ContractFailed(object sender, ContractFailedEventArgs e)
        {
            throw new AIMException(e.Message);
        }
        public static List<AllClientsContact> MapToAllClientsContact(XElement responseElement)
        {
            Contract.Requires(responseElement != null);
            List<AllClientsContact> result = new List<AllClientsContact>();
            FileInfo info = new FileInfo(String.Format("{0}{1}", Properties.Settings.Default.XslPath, "allclients-portal.xslt"));
            responseElement.Descendants("contact").ToList().ForEach(n =>
            {
                XElement transformation = CommonService.Transform(n, info);
                AllClientsContact deserializedObject = CommonService.FromXml(typeof(AllClientsContact), transformation.ToString()) as AllClientsContact;

                if (deserializedObject != null)
                    result.Add(deserializedObject);
            });

            return result;
        }
        public static AllClientsContactExport MapToAllClientsContactExport(AllClientsContact contact, List<AllClientsWebform> webforms, AllClientsAccount account)
        {
            var result = new AllClientsContactExport();
            result.Contact = contact;
            result.AllClientsWebform = webforms.SingleOrDefault(n => n.WebformType == (Enumerations.WebformType)Enum.Parse(typeof(Enumerations.WebformType), contact.Categories.First().Id));
            result.Account = account;
            return result;
        }
        public static XElement CreateAccount(string email, string password, string group, string newsletter, string fullname, string company, string address, string citystatezip, string phone, string website, int importTypeId, bool enableUpdates, bool active, XElement clientParameters)
        {
            Contract.Requires(!String.IsNullOrEmpty(group));
            IClient newClient = null;
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("apiusername", "x6knh8g83dsc4dqr");
            parameters.Add("apipassword", "9keyceyf3mtf7tza");
            if (!string.IsNullOrEmpty(email))
                parameters.Add("email", email.Trim());
            if (!string.IsNullOrEmpty(password))
                parameters.Add("password", password.Trim());
            if (!string.IsNullOrEmpty(group))
                parameters.Add("group", group.Trim());
            if (!string.IsNullOrEmpty(fullname))
                parameters.Add("mailmerge_fullname", fullname.Trim());
            if (!string.IsNullOrEmpty(company))
                parameters.Add("mailmerge_company", company.Trim());
            if (!string.IsNullOrEmpty(newsletter))
                parameters.Add("mailmerge_newsletter", newsletter.Trim());
            if (!string.IsNullOrEmpty(address))
                parameters.Add("mailmerge_address", address.Trim());
            if (!string.IsNullOrEmpty(citystatezip))
                parameters.Add("mailmerge_citystatezip", citystatezip.Trim());
            if (!string.IsNullOrEmpty(phone))
                parameters.Add("mailmerge_phone", phone.Trim());
            parameters.Add("mailmerge_email", email.Trim());
            if (!string.IsNullOrEmpty(website))
                parameters.Add("mailmerge_website", website.Trim());

            XElement response = CommonService.AllClientsRequest("AddAccount.aspx", parameters);
            if (response.Descendants("apikey").Count() > 0)
            {

                using (DomainContext ctx = new DomainContext())
                {
                    Manager mgr = new Manager(ctx);
                    ClientManager clientManager = new ClientManager(mgr);
                    newClient = clientManager.GetNewClient();
                    newClient.AccountId = int.Parse(response.Descendants("accountid").Single().Value);
                    newClient.Active = active;
                    newClient.ApiKey = response.Descendants("apikey").Single().Value;
                    newClient.Company = company.Trim();
                    newClient.Created = System.DateTime.Now;
                    newClient.Updated = System.DateTime.Now;
                    newClient.ImportTypeId = importTypeId;
                    newClient.EnableUpdates = enableUpdates;
                    newClient.ClientParameters = clientParameters;
                    newClient.ClientProperties.AllClientsUsername = email;
                    newClient.ClientProperties.AllClientsPassword = password;
                    ctx.SubmitChanges();
                }
            }
            else
            {
                if (response.Descendants("error").Count() > 0)
                    throw new AccountSetupException(String.Format("All Clients Returned an error on account creation: {0}", response.Descendants("error").First().Value));
            }

            return response;

        }
        public static List<AllClientsContactExport> SaveContacts(List<AllClientsContactExport> contactExports)
        {
            List<AllClientsContactExport> errors = new List<AllClientsContactExport>();
            if (contactExports.Count > 0)
            {
                using (DomainContext ctx = new DomainContext())
                {
                    Manager mgr = new Manager(ctx);
                    ContactManager contactManager = new ContactManager(mgr);
                    ClientManager clientManager = new ClientManager(mgr);


                    IClient client = clientManager.GetByCompany(contactExports.First().Account.ClientName);
                    contactExports.ForEach(export =>
                        {
                            try
                            {
                                XElement element = new XElement("Export");
                                XElement account = Common.Services.CommonService.ToXml(typeof(AllClientsAccount), export.Account);
                                XElement webform = Common.Services.CommonService.ToXml(typeof(AllClientsWebform), export.AllClientsWebform);
                                XElement contact = Common.Services.CommonService.ToXml(typeof(AllClientsContact), export.Contact);
                                element.Add(account);
                                element.Add(webform);
                                element.Add(contact);

                                IContact newContact = contactManager.GetNewContact();
                                newContact.ContactElement = element;
                                newContact.ClientId = client.Id;
                            }
                            catch
                            {
                                errors.Add(export);
                            }
                            finally
                            {
                                ctx.SubmitChanges();
                            }
                        });
                }

            }
            return errors;
        }

        static void AddCustomElement(XElement contactElement, CustomElement customElement)
        {
            XElement customElementType = new XElement("{http://www.aimscrm.com/schema/2011/common/contact}CustomElement");
            XElement nameElement = new XElement("{http://www.aimscrm.com/schema/2011/common/contact}Name", customElement.Name);
            XElement valueElement = new XElement("{http://www.aimscrm.com/schema/2011/common/contact}Value", customElement.Value);
            customElementType.Add(nameElement);
            customElementType.Add(valueElement);
            contactElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}Custom").Add(customElementType);
        }

        public static void MapBirthdate(XElement allClientsContact)
        {
            var stringValue = String.Empty;
            DateTime test = System.DateTime.Now;
            if (allClientsContact.Descendants("{http://www.aimscrm.com/schema/2011/common/contact}Birthday").Count() > 0)
            {
                var birthdayElement = allClientsContact.Descendants("{http://www.aimscrm.com/schema/2011/common/contact}Birthday").First();
                stringValue = birthdayElement.Value;
                birthdayElement.Remove();
            }
            else
            {
                var customElements = allClientsContact.Descendants("{http://www.aimscrm.com/schema/2011/common/contact}CustomElement");
                var birthdayElement = customElements.Descendants("{http://www.aimscrm.com/schema/2011/common/contact}Name").Where(x => x.Value != null && x.Value == "Birthday").FirstOrDefault();
                if (birthdayElement != null)
                {
                    stringValue = birthdayElement.Parent.Elements("{http://www.aimscrm.com/schema/2011/common/contact}Value").First().Value;
                }
            }


            if (DateTime.TryParse(stringValue, out test))
            {

                AddCustomElement(allClientsContact, new CustomElement { Name = "birthday_month", Value = test.Month.ToString() });
                AddCustomElement(allClientsContact, new CustomElement { Name = "birthday_day", Value = test.Day.ToString() });
                AddCustomElement(allClientsContact, new CustomElement { Name = "birthday_year", Value = test.Year.ToString() });
            }

        }
        public static bool AddRemoveFlag(AllClientsAccount account, bool remove, string emailAddress, string flag)
        {
            bool result = false;
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            parameters.Add("accountId", account.AccountId.ToString());
            parameters.Add("apikey", account.APIKey);
            parameters.Add("identifyMethod", "2");
            parameters.Add("identifyValue", emailAddress);
            //1 for add flag 2 for remove
            parameters.Add("mode", remove ? "2" : "1");
            parameters.Add("flag", flag);
            var messageResult = CommonService.AllClientsRequest("ContactFlags.aspx", parameters) as XElement;
            result = messageResult != null && messageResult.Element("message").Value == "Success";
            return result;

        }
        public static List<AllClientsContact> GetExistingContacts(IClient client)
        {
            List<AllClientsContact> result = null;
            using (DomainContext ctx = new DomainContext())
            {

                result = ctx.Contact.Where(n => n.ClientId == client.Id)
                    .Select(n => CommonService.FromXml(typeof(AllClientsContact), n.ContactElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}AllClientsContact")
                        .ToString())).OfType<AllClientsContact>().ToList();
            }
            return result;
        }
        public static List<AllClientsContact> MapAppointmentNotifications(XElement mindBodyResponse)
        {
            var result = new List<AllClientsContact>();
            return result;
        }
    }
}
