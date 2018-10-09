using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AspNetMvc.QuickStart.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Software> Softwares { get; set; }
    }
}