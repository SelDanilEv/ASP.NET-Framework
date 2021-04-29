namespace Lab4.Repository
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