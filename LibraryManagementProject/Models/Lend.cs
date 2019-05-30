using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementProject.Models;


namespace LibraryManagementProject.Models
{
    public class Lend
    {
        public int LendId { get; set; }
        public DateTime LendDate { get; set; }
        public Book Book { get; set; }
        public LibraryUser User { get; set; }
    }
}
