namespace Lab6_EntityLibrary
{
    using Infrastructure;
    using System.Data.Entity;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DBConnection")
        { }

        public DbSet<TelephoneNote> TelephoneNotes { get; set; }
    }
}