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
    /// Summary description for MindBodyServiceTests
    /// </summary>
    [TestClass]
    public class MindBodyServiceTests
    {
        public MindBodyServiceTests()
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

        [TestMethod]
        public void MapExportTest_WhenLeadToCustomer_CheckFormIsLeadToCustomer()
        {
            //Arrange
            XDocument doc = XDocument.Load(String.Format("{0}\\Resources\\MBSingleCustomerRow.xml", AppDomain.CurrentDomain.BaseDirectory));
            XElement mbResponseRowActiveCustomer = doc.Descendants("{http://clients.mindbodyonline.com/API/0_4}Row").First();
            List<AllClientsContact> existingContacts = new List<AllClientsContact>();
            
           
            AllClientsContact variableContact = new AllClientsContact
            {
                City = "SomeCity",
                Email = "lktavi@comcast.net",
                FirstName = "Billy",
                LastName = "Bob",
                Phone = "111-222-3333",
                Zip = "12345",
                Flags = new List<Flag>
                      {
                          new Flag
                          {
                              Id="605",
                              Name="Prospect/Lead"
                          }
                      }
            };
            
            existingContacts.Add(variableContact);
            //Act
            AllClientsContactExport actual = MindBodyService.MapExport(existingContacts, CommonHelpers.GetSampleAccount(),CommonHelpers.GetSampleClient(), CommonHelpers.GetSampleWebforms(), mbResponseRowActiveCustomer);
            
            //Assert
            Assert.IsTrue(actual.AllClientsWebform.WebformType == Types.Enumerations.WebformType.LeadToCustomer);
        }
    }
}
