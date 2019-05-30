using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementProject.Models;

namespace LibraryManagementProject.Models
{
    public class Home
    {
        public int UsersCount { get; set; }

        public int AuthorsCount { get; set; }

        public int BooksCount { get; set; }
        public int LendedBooksCount { get; set; }

    }
}
