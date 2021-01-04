using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BookCategoryModel
    {
        public int BookCategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public string Description { get; set; }
    }
}