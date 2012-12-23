using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
namespace AIM.Workflows
{

    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("workflow", args[0]);
            WorkflowInvoker.Invoke(new Main(),parameters);
        }
    }
}
