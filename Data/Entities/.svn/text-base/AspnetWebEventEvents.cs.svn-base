using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;

namespace AIM.Data
{
    public partial class AspnetWebEventEvents
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            [Required]
            public string EventId { get; set; }

            public System.DateTime EventTimeUtc { get; set; }

            public System.DateTime EventTime { get; set; }

            [Required]
            public string EventType { get; set; }

            public decimal EventSequence { get; set; }

            public decimal EventOccurrence { get; set; }

            public int EventCode { get; set; }

            public int EventDetailCode { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
            public string Message { get; set; }

            public string ApplicationPath { get; set; }

            public string ApplicationVirtualPath { get; set; }

            [Required]
            public string MachineName { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
            public string RequestUrl { get; set; }

            public string ExceptionType { get; set; }

            public string Details { get; set; }

        }

        #endregion
    }
}