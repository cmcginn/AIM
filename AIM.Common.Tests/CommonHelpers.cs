using AIM.Common.Services;
using System;
using System.Xml.Linq;
using AIM.Common.Types;
using AIM.Common.Types.AllClients;
using System.Diagnostics.Contracts;
using AIM.Data;
using System.Collections.Generic;
using System.Linq;

namespace AIM.Common.Tests
{
    public class CommonHelpers
    {
        public static Guid WellKnownAccountID = new Guid("629B8D2D-A8BD-413A-BDC6-863EB7C87645");
        public static List<AllClientsWebform> GetSampleWebforms()
        {
            List<AllClientsWebform> result = new List<AllClientsWebform>();



            XElement webforms = XElement.Load(String.Format("{0}\\Resources\\AllClientsWebforms.xml", AppDomain.CurrentDomain.BaseDirectory));

            //standard form names
            string leadToCustomerFormName = "5. sys_action_import_lead to customer";
            string customerFormName = "4. sys_action_import_customer";
            string customerInactiveFormName = "2. sys_action_import_customer_inactive";
            string leadFormName = "3. sys_action_import_lead";
            string newCustomerFormName = "1. sys_action_import_customer_new";
            //webforms from All Clients as Elements
            XElement leadToCustomerForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == leadToCustomerFormName).First();
            XElement customerForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == customerFormName).First();
            XElement customerInactiveForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == customerInactiveFormName).First();
            XElement leadForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == leadFormName).First();
            XElement newCustomerForm = webforms.Descendants("webform").Where(n => n.Element("name").Value == newCustomerFormName).First();
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
            newCustomerWebform.FormKey = leadForm.Element("formkey").Value;


            //Assign Accounts 

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



            return result;
        }
        public static AllClientsAccount GetSampleAccount()
        {
            AllClientsAccount result = new AllClientsAccount
            {
                AccountId = 2326,
                Active = true,
                APIKey = "44E7D143D6CF3B3EEF56FB6191BC7562",
                ClientName = "DeveloperTest01",
                Group = "Fitness Owners"
            };
            return result;
        }
        public static IClient GetSampleClient()
        {
            Client result = null;
            using (DomainContext ctx = new DomainContext())
            {
                result = ctx.Client.Where(n => n.Id == WellKnownAccountID).Single(); 
            }
            return result;
        }
    }
}
