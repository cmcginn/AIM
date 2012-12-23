using System.ComponentModel.DataAnnotations;
using System.Web;
using AIM.Administration.Models.Validators;

namespace AIM.Administration.Models.ViewModels
{
    public class ImportForm
    {
        public bool FirstRowContainsColumnHeadings { get; set; }
        [Required]
        public string Category { get; set; }
        public string Flag { get; set; }
        [Required(ErrorMessage = "Please Choose a valid CSV file")]
        [File(AllowedFileExtensions = new string[] { ".csv" }, ErrorMessage = "Invalid File")]
        public HttpPostedFileBase File { get; set; }
    }
}