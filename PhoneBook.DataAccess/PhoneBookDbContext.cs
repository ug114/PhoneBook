using System.Data.Entity;
using PhoneBook.DataAccess.Models;

namespace PhoneBook.DataAccess
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public PhoneBookDbContext() : base("PhoneBookConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Contact>().Property(c => c.Phone).HasMaxLength(30);

            base.OnModelCreating(modelBuilder);
        }
    }
}
