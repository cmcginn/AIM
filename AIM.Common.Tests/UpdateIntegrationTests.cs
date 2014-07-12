using AIM.Common.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;
using AIM.Common.Types.AllClients;
using System.Diagnostics.Contracts;
using AIM.Data;
using System.Collections.Generic;
using System.Linq;
using AIM.Common.Types.MindBody;
namespace AIM.Common.Tests
{
    /// <summary>
    /// Summary description for UpdateIntegrationTests
    /// </summary>
    [TestClass]
    public class UpdateIntegrationTests
    {
        public UpdateIntegrationTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        static Client GetTestClient()
        {
            DomainContext ctx = new DomainContext();
            var result = ctx.Client.Where(n => n.Id == new Guid("3E7930E4-524B-4814-AF47-90E39D5E555A")).Single();
            return result;
        }

        static List<Contact> GetExistingContacts(Client client)
        {
            
            DomainContext ctx = new DomainContext();
            var result = ctx.Contact.Where(n => n.ClientId == client.Id).ToList();
            return result;
        }

        static XElement GetMindBodyContacts(Client client)
        {
            var mbAccount = MindBodyService.GetMindBodyAccount(client);
            string selectStatement = "SELECT TOP {0} * FROM CLIENTS WHERE EMAILNAME IS NOT NULL AND SUSPENDED = 0 AND DELETED = 0 ORDER BY ClientID DESC";
            var result = MindBodyService.SelectServiceRequest(mbAccount);            
            return result;
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Make method
            var existingAccounts = GetExistingContacts(GetTestClient()).Select(n => CommonService.FromXml(typeof(AllClientsContact), n.ContactElement.Element("{http://www.aimscrm.com/schema/2011/common/contact}AllClientsContact").ToString())).OfType<AllClientsContact>().ToList();
            var imports = GetMindBodyContacts(GetTestClient()).Descendants("{http://clients.mindbodyonline.com/API/0_4}Row").ToList();
            var ac = GetTestClient();
            var allClientsAccount = new AllClientsAccount
            {
                 AccountId=ac.AccountId,
                 Active=true,
                 APIKey=ac.ApiKey
            };
            var webForms = AllClientsService.GetAllClientsWebforms(allClientsAccount);
            List<AllClientsContactExport> result = new List<AllClientsContactExport>();
            imports.ForEach(n =>
                {
                    var export = MindBodyService.MapExport(existingAccounts, allClientsAccount,ac, webForms, n);
                    result.Add(export);
                });


            Assert.IsTrue(result.Count > 0);
        }
    }
}
