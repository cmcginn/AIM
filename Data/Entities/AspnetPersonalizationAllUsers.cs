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
    public partial class AspnetPersonalizationAllUsers
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public System.Guid PathId { get; set; }

            public System.Data.Linq.Binary PageSettings { get; set; }

            public System.DateTime LastUpdatedDate { get; set; }

            public AspnetPaths AspnetPaths { get; set; }

        }

        #endregion
    }
}