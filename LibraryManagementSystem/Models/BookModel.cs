using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookCategoryId { get; set; }
        public int AuthorId { get; set; }
        public int SubjectId { get; set; }
        public string Remarks { get; set; }
    }
}