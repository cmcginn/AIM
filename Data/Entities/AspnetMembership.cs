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
    public partial class AspnetMembership
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public System.Guid ApplicationId { get; set; }

            public System.Guid UserId { get; set; }

            [Required]
            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string Password { get; set; }

            public int PasswordFormat { get; set; }

            [Required]
            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string PasswordSalt { get; set; }

            public string MobilePIN { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
            public string Email { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
            public string LoweredEmail { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string PasswordQuestion { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string PasswordAnswer { get; set; }

            public bool IsApproved { get; set; }

            public bool IsLockedOut { get; set; }

            [Now(EntityState.New)]
            [CodeSmith.Data.Audit.NotAudited]
            public System.DateTime CreateDate { get; set; }

            public System.DateTime LastLoginDate { get; set; }

            public System.DateTime LastPasswordChangedDate { get; set; }

            public System.DateTime LastLockoutDate { get; set; }

            public int FailedPasswordAttemptCount { get; set; }

            public System.DateTime FailedPasswordAttemptWindowStart { get; set; }

            public int FailedPasswordAnswerAttemptCount { get; set; }

            public System.DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }

            public string Comment { get; set; }

            public AspnetApplications AspnetApplications { get; set; }

            public AspnetUsers AspnetUsers { get; set; }

        }

        #endregion
    }
}