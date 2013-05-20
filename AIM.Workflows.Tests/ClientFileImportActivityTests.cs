using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using AIM.Workflows;
using System.Activities;
using Microsoft.Activities.UnitTesting;
using AIM.Workflows.FileUpload;
namespace AIM.Workflows.Tests {
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class ClientFileImportActivityTests {
    public ClientFileImportActivityTests() {
      //
      // TODO: Add constructor logic here
      //
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext {
      get {
        return testContextInstance;
      }
      set {
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
    public void FileImportActivityRunTest() {

    
      WorkflowInvoker.Invoke( new ClientFileImportActivity(), new Dictionary<string, object> { { "clientId", new Guid( "E46AF308-475A-4A26-8D67-301A6B4AD332" ) },{"importFile", new System.IO.FileInfo( "c:/temp/SampleImportFile.20111105103542.xml" ) }} );

    }

    [TestMethod]
    public void InvokeMain()
    {
        Dictionary<string, object> args = new Dictionary<string, object>();
        args.Add("workflow", "mindbodyimport");
        var target = WorkflowInvokerTest.Create(new Main(),args);

        target.TestActivity(TimeSpan.FromMinutes(2));
        // WorkflowInvoker.Invoke(new MindBody.MindBodyContactImportActivity());
    }
    [TestMethod]
    public void InvokeMindBodyAppointmentImport()
    {
        var target = WorkflowInvokerTest.Create(new MindBody.MindBodyAppointmentImportActivity());

        target.TestActivity(TimeSpan.FromMinutes(2));
        // WorkflowInvoker.Invoke(new MindBody.MindBodyContactImportActivity());
    }
    [TestMethod]
    public void InvokeMindBodyImport()
    {
        var target = WorkflowInvokerTest.Create(new MindBody.MindBodyContactImportActivity());

        target.TestActivity(TimeSpan.FromMinutes(2));
        // WorkflowInvoker.Invoke(new MindBody.MindBodyContactImportActivity());
    }
    [TestMethod]
    public void DeleteOldLogEntriesTest()
    {
        Utilities.DeleteOldLogEntries();
    }
     

  }
}
