using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryManagementProject.Models;

namespace LibraryManagementProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<LibraryUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LibraryManagementProject.Models.Book> Books { get; set; }
        public DbSet<LibraryManagementProject.Models.Author> Authors { get; set; }
        public DbSet<LibraryManagementProject.Models.Lend> Lends { get; set; }
        public DbSet<LibraryManagementProject.Models.Category> Categories { get; set; }
    }
}

