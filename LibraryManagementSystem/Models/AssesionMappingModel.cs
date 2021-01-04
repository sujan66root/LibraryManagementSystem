using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class AssesionMappingModel
    {
        public int AssesionId { get; set; }
        public int BookId { get; set; }
        public Nullable<byte> Status { get; set; }
    }
}