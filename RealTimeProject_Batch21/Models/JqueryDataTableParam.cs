using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace RealTimeProject_Batch21.Models
{
    public class JqueryDataTableParam
    {
        public string Search { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Columns { get; set; }
        public string SortColumn { get;set; }
        public string SortOrder { get; set; } 
    }
}
