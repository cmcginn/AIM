using System.Collections.Generic;
using System.Web.Mvc;


namespace AIM.Administration.Models.ViewModels
{
    public class FieldMapperViewModel
    {        
        public List<CsvColumn> ColumnMaps { get; set; }
        public List<SelectListItem> Fields { get; set; }
    }
}