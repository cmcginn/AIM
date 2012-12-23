using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Web;
using System.Linq;

namespace AIM.Administration.Models.Validators
{
    public class FileAttribute : ValidationAttribute
    {
        public string[] AllowedFileExtensions;
        public string[] AllowedContentTypes;

        public override bool IsValid(object value)
        {

            var file = value as HttpPostedFileBase;

            string maxFileSize = ConfigurationManager.AppSettings["MaxCsvFileSize"];
            int maxContentLength = int.Parse(maxFileSize) * 1024 * 1024;

            //this should be handled by [Required])
            if (file == null)
                return true;

            if (file.ContentLength > maxContentLength)
            {
                ErrorMessage = string.Format("The file is too big (Max {0}MB)", maxContentLength / (1024 * 1024));
                return false;
            }

            if (AllowedFileExtensions != null)
            {
                if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    //ErrorMessage = "Please upload file of type: " + string.Join(", ", AllowedFileExtensions);
                    ErrorMessage = string.Format("Only {0} allowed", string.Join(", ", AllowedFileExtensions));
                    return false;
                }
            }

            if (AllowedContentTypes != null)
            {
                if (!AllowedContentTypes.Contains(file.ContentType))
                {
                    ErrorMessage = "Please upload file of type: " + string.Join(", ", AllowedContentTypes);
                    return false;
                }
            }

            return true;
        }
    }
}