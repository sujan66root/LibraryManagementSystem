using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class FineModel
    {
        public int FineId { get; set; }
        public Nullable<int> LateDays { get; set; }
        public int MemberCategoryId { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}