using Lab4.Models.BasicModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab4.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DBConnection")
        { }

        public DbSet<TelephoneNote> TelephoneNotes { get; set; }
    }
}