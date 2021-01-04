using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int MemberCategoryId { get; set; }
        public string MemberAddress { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<byte> Status { get; set; }
    }
}