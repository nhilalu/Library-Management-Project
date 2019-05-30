using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementProject.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementProject.Models
{
    public class LibraryUser : IdentityUser
    {
        public List<Lend> Lends { get; set; } = new List<Lend>();
    }
}
