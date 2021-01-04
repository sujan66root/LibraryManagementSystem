using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BookIssueReturnModel
    {
        public int BookIssueReturnId { get; set; }
        public int MemberId { get; set; }
        public Nullable<int> AssesionId { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<int> LateDays { get; set; }
        public string FineAmount { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<int> MemberCategoryId { get; set; }
        public string Remarks { get; set; }
    }
}