using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementProject.Models;

namespace LibraryManagementProject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string SerialNumber { get; set; }
        public string Publisher { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Author Author { get; set; }

        public int? LendId { get; set; }
        public Lend Lend { get; set; }
    }
}
