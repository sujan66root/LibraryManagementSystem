//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fine
    {
        public int FineId { get; set; }
        public Nullable<int> LateDays { get; set; }
        public int MemberCategoryId { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    
        public virtual MemberCategory MemberCategory { get; set; }
    }
}
