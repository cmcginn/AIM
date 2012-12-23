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
    public partial class ClientFileImport
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public System.Guid Id { get; set; }

            public System.Guid ClientId { get; set; }

            [Required]
            public string UploadFilePath { get; set; }

            [Required]
            public string ImportedFilePath { get; set; }

            public int RecordsImported { get; set; }

            public int RecordsFailed { get; set; }

            public System.DateTime LastUpdated { get; set; }

            public System.DateTime? Processed { get; set; }

            public Client Client { get; set; }

        }

        #endregion
    }
}