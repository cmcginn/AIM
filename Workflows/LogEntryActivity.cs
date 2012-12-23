using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using AIM.Common.Types;
using System.Diagnostics;
namespace AIM.Workflows
{

    public sealed class LogEntryActivity : CodeActivity
    {
        LogEntry entry;
        Enumerations.LogCategory category;
        Guid activityId;
        string title;
        List<String> messages;
        string message;
        List<Enumerations.LogCategory> categories;
        int eventId;
        TraceEventType severity;
        Dictionary<string, object> extendedProperties;
        Exception exception;
        // Define an activity input argument of type string
        public InArgument<Enumerations.LogCategory> Category { get; set; }
        public InArgument<Guid> ActivityId { get; set; }
        public InArgument<string> Title { get; set; }
        public InArgument<List<String>> Messages { get; set; }
        public InArgument<String> Message { get; set; }
        public InArgument<List<Enumerations.LogCategory>> Categories { get; set; }
        public InArgument<int> EventId { get; set; }
        public InArgument<Dictionary<string, object>> ExtendedProperties { get; set; }
        public InArgument<TraceEventType> Severity { get; set; }
        public InArgument<Exception> Exception { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            if (context.GetValue<List<Enumerations.LogCategory>>(this.Categories) != null)
                categories = context.GetValue<List<Enumerations.LogCategory>>(this.Categories);
            else
                categories = new List<Enumerations.LogCategory>();

            if (context.GetValue<Enumerations.LogCategory>(this.Category) != Enumerations.LogCategory.None)
                categories.Add(context.GetValue<Enumerations.LogCategory>(this.Category));

            if (context.GetValue<Guid>(this.ActivityId) != null)
                activityId = context.GetValue<Guid>(this.ActivityId);
            if (context.GetValue<string>(this.Title) != null)
                title = context.GetValue<string>(this.Title).ToString();
            if (context.GetValue<List<String>>(this.Messages) != null)
                messages = context.GetValue<List<String>>(this.Messages);
            else
                messages = new List<String>();
            if (context.GetValue<String>(this.Message) != null)
                messages.Add(context.GetValue<String>(this.Message));
            if (context.GetValue<Dictionary<string, object>>(this.ExtendedProperties) != null)
                extendedProperties = context.GetValue<Dictionary<string, object>>(this.ExtendedProperties);
            if (context.GetValue<Exception>(this.Exception) != null)
                exception = context.GetValue<Exception>(this.Exception);
            severity = context.GetValue<TraceEventType>(this.Severity);
            BuildLogEntry();
            try
            {
                Logger.Write(entry);
            }
            catch
            {
                //swallow
            }
            //messages.Clear();


        }

        void BuildLogEntry()
        {
            entry = new LogEntry();
            entry.Categories = categories.Select(n => n.ToString()).ToList();
            var ex = exception;

            while (ex != null)
            {
                messages.Add(String.Format("Exception:{0}:Source:{1}:Site:{2}:StackTrace:{3};", ex.Message, ex.Source, ex.TargetSite, ex.StackTrace));
                ex = ex.InnerException;
            }
            messages.ForEach(n => entry.Message += String.Format("{0}|", n));
            entry.ActivityId = activityId;
            entry.Title = title != null ? title : "Generic";
            entry.Severity = severity;
            entry.EventId = eventId;
            if (extendedProperties != null)
                entry.ExtendedProperties = extendedProperties;
        }
    }
}