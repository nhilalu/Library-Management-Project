using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementProject.Models;

namespace LibraryManagementProject.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
    }
}
