using AIM.Common.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;
using AIM.Common.Types.AllClients;
using System.Diagnostics.Contracts;
using AIM.Data;
using System.Collections.Generic;
using System.Linq;
namespace AIM.Common.Tests
{
    
    
    /// <summary>
    ///This is a test class for AllClientsServiceTest and is intended
    ///to contain all AllClientsServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AllClientsServiceTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region Helpers

        static XElement GetWellKnownContactElement()
        {
            XElement result = XElement.Parse(@"<AllClientsContact xmlns=""http://www.aimscrm.com/schema/2011/common/contact"">
  <FirstName>TestFirstName</FirstName>
  <LastName>TestLastName</LastName>
  <City>TestCity</City>
  <State>FL</State>
  <Zip>33333</Zip>
  <Email>test@test.com</Email>
  <Phone>1111111111</Phone>
  <Custom>
    <CustomElement>
      <Name>birthday_month</Name>
      <Value>1</Value>
    </CustomElement>
    <CustomElement>
      <Name>birthday_day</Name>
      <Value>1</Value>
    </CustomElement>
    <CustomElement>
      <Name>birthday_year</Name>
      <Value>1979</Value>
    </CustomElement>
  </Custom>
</AllClientsContact>");
            return result;
        }
        static AllClientsContact GetTestContact()
        {
            AllClientsContact result = new AllClientsContact
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                City = "TestCity",
                State = "FL",
                Zip = "33333",
                Phone = "1111111111"
            };
            result.Categories.Add(new Category { Id = "1", Name = "TestCategory" });
            result.Flags.Add(new Flag { Id = "1", Name = "TestFlag1" });
            result.Flags.Add(new Flag { Id = "2", Name = "TestFlag2" });
            return result;
        }

        #endregion
        /// <summary>
        ///A test for AllClientsService Constructor
        ///</summary>
        [TestMethod()]
        public void AllClientsServiceConstructorTest()
        {
            AllClientsService target = new AllClientsService();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddCustomElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AIM.Common.dll")]
        public void AddCustomElementTest()
        {
            XElement contactElement = null; // TODO: Initialize to an appropriate value
            CustomElement customElement = null; // TODO: Initialize to an appropriate value
            AllClientsService_Accessor.AddCustomElement(contactElement, customElement);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Contract_ContractFailed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AIM.Common.dll")]
        public void Contract_ContractFailedTest()
        {
            object sender = null; // TODO: Initialize to an appropriate value
            ContractFailedEventArgs e = null; // TODO: Initialize to an appropriate value
            AllClientsService_Accessor.Contract_ContractFailed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateAccount
        ///</summary>
        [TestMethod()]
        public void CreateAccountTest()
        {
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            string group = string.Empty; // TODO: Initialize to an appropriate value
            string fullname = string.Empty; // TODO: Initialize to an appropriate value
            string company = string.Empty; // TODO: Initialize to an appropriate value
            string address = string.Empty; // TODO: Initialize to an appropriate value
            string citystatezip = string.Empty; // TODO: Initialize to an appropriate value
            string phone = string.Empty; // TODO: Initialize to an appropriate value
            string website = string.Empty; // TODO: Initialize to an appropriate value
            string newsletter = string.Empty;
            bool enableUpdates = true;
            int importTypeId = 0; // TODO: Initialize to an appropriate value
            bool active = false; // TODO: Initialize to an appropriate value
            XElement clientParameters = null; // TODO: Initialize to an appropriate value
            XElement expected = null; // TODO: Initialize to an appropriate value
            XElement actual;
            actual = AllClientsService.CreateAccount(email, password, group, newsletter, fullname, company, address, citystatezip, phone, website, importTypeId,enableUpdates, active, clientParameters);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExportContact
        ///</summary>
        [TestMethod()]
        public void ExportContactTest()
        {
            AllClientsContactExport export = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AllClientsService.ExportContact(export);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllClientsAccount
        ///</summary>
        [TestMethod()]
        public void GetAllClientsAccountTest()
        {
            IClient client = null; // TODO: Initialize to an appropriate value
            AllClientsAccount expected = null; // TODO: Initialize to an appropriate value
            AllClientsAccount actual;
            actual = AllClientsService.GetAllClientsAccount(client);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllClientsWebforms
        ///</summary>
        [TestMethod()]
        public void GetAllClientsWebformsTest()
        {
            AllClientsAccount account = null; // TODO: Initialize to an appropriate value
            List<AllClientsWebform> expected = null; // TODO: Initialize to an appropriate value
            List<AllClientsWebform> actual;
            actual = AllClientsService.GetAllClientsWebforms(account);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetContacts
        ///</summary>
        [TestMethod()]
        public void GetContactsTest()
        {
            DomainContext ctx = new DomainContext();
            var client = ctx.Client.Where(n => n.Id == new Guid("3E7930E4-524B-4814-AF47-90E39D5E555A")).Single();
            AllClientsAccount account = new AllClientsAccount
            {
                AccountId = 2308,
                Active = true,
                APIKey = client.ApiKey,
                ClientName = "DeveloperTesting"
            };
                    
            
           
            XElement actual;
            actual = AllClientsService.GetContacts(account);
            
            Assert.IsTrue(actual.Descendants().Count() > 0);
            
        }

        /// <summary>
        ///A test for MapBirthdate
        ///</summary>
        [TestMethod()]
        public void MapBirthdateTest()
        {
            XElement allClientsContact = XElement.Parse(@"<AllClientsContact xmlns=""http://www.aimscrm.com/schema/2011/common/contact"">
  <FirstName>TestFirstName</FirstName>
  <LastName>TestLastName</LastName>
  <City>TestCity</City>
  <State>FL</State>
  <Zip>33333</Zip>
  <Email>test@test.com</Email>
  <Phone>1111111111</Phone>
  <Custom>
	<birthday_month xmlns="""">1</birthday_month>
	<birthday_day xmlns="""">1</birthday_day>
	<birthday_year xmlns="""">1970</birthday_year>
  </Custom>
</AllClientsContact>");
            AllClientsService.MapBirthdate(allClientsContact);
            XElement customElement = allClientsContact.Element("{http://www.aimscrm.com/schema/2011/common/contact}Custom");
            Assert.IsTrue(customElement.Elements().Count() == 3);
        }

       

        /// <summary>
        ///A test for SaveContacts
        ///</summary>
        [TestMethod()]
        public void SaveContactsTest()
        {
            List<AllClientsContactExport> contactExports = null; // TODO: Initialize to an appropriate value
            List<AllClientsContactExport> expected = null; // TODO: Initialize to an appropriate value
            List<AllClientsContactExport> actual;
            actual = AllClientsService.SaveContacts(contactExports);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        #region Custom tests
        [TestMethod()]
        public void ContactSerializes_With3CustomElements_CheckCustomElementCountIs3()
        {
            XElement contactElement = XElement.Parse(@"<AllClientsContact xmlns=""http://www.aimscrm.com/schema/2011/common/contact"">
  <FirstName>TestFirstName</FirstName>
  <LastName>TestLastName</LastName>
  <City>TestCity</City>
  <State>FL</State>
  <Zip>33333</Zip>
  <Email>test@test.com</Email>
  <Phone>1111111111</Phone>
  <Custom>
    <CustomElement>
      <Name>birthday_month</Name>
      <Value>1</Value>
    </CustomElement>
    <CustomElement>
      <Name>birthday_day</Name>
      <Value>1</Value>
    </CustomElement>
    <CustomElement>
      <Name>birthday_year</Name>
      <Value>1979</Value>
    </CustomElement>
  </Custom>
</AllClientsContact>");


            AllClientsContact actual = CommonService.FromXml(typeof(AllClientsContact), contactElement.ToString()) as AllClientsContact;
            Assert.IsTrue(actual.Custom.Count == 3);
        }
        [TestMethod()]
        public void AddCustomElementTest_CheckAddsCustomElementTags()
        {
            XElement contactElement = XElement.Parse(@"<AllClientsContact xmlns=""http://www.aimscrm.com/schema/2011/common/contact"">
  <FirstName>TestFirstName</FirstName>
  <LastName>TestLastName</LastName>
  <City>TestCity</City>
  <State>FL</State>
  <Zip>33333</Zip>
  <Email>test@test.com</Email>
  <Phone>1111111111</Phone>
  <Custom/>
</AllClientsContact>");
            AllClientsService_Accessor.AddCustomElement(contactElement, new CustomElement { Name = "birthday_month", Value = "1" });
            AllClientsService_Accessor.AddCustomElement(contactElement, new CustomElement { Name = "birthday_day", Value = "1" });
            AllClientsService_Accessor.AddCustomElement(contactElement, new CustomElement { Name = "birthday_year", Value = "1979" });

            Assert.IsTrue(contactElement.Descendants("{http://www.aimscrm.com/schema/2011/common/contact}CustomElement").Count() == 3);
            
        }

        [TestMethod()]
        public void ParametersCollection_CheckParametersCorrect()
        {

        }
        #endregion

        /// <summary>
        ///A test for GetContactExportParameters
        ///</summary>
        [TestMethod()]
        public void GetContactExportParametersTest()
        {
            AllClientsAccount account = new AllClientsAccount
            {
                AccountId = 1000,
                APIKey = "123456789"
            };
            AllClientsWebform webform = new AllClientsWebform
            {
                Account = account,
                FormKey = "123",
                FormName = "TestForm",
                WebformType = Types.Enumerations.WebformType.ActiveCustomer
            };

            AllClientsContactExport export = new AllClientsContactExport();
            export.AllClientsWebform = webform;
            export.Account = account;
            export.Contact = CommonService.FromXml(typeof(AllClientsContact), GetWellKnownContactElement().ToString()) as AllClientsContact;

            
            Dictionary<string, string> actual;
            actual = AllClientsService.GetContactExportParameters(export);
            Assert.IsTrue(actual.ContainsKey("accountid"));
            Assert.IsTrue(actual.ContainsKey("apikey"));
            Assert.IsTrue(actual.ContainsKey("birthday_month"));
            Assert.IsTrue(actual.ContainsKey("birthday_day"));
            Assert.IsTrue(actual.ContainsKey("birthday_year"));
        }

        [TestMethod]
        public void AddRemoveFlagTest()
        {
            //Arrange
            var client = CommonHelpers.GetSampleAccount();
            var targetEmail = "TestContact0strong42@hotmail.com";
            //Act
            var actual = AllClientsService.AddRemoveFlag(client, true, targetEmail, "Prospect/Lead");
            //Assert
            Assert.IsTrue(actual);
        }
    }
}
