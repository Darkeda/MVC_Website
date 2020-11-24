using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_Course_Project.Models
{
    public class BookLibraryContex : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public System.Data.Entity.DbSet<Library_Course_Project.Models.Book> Books { get; set; }
    }
}