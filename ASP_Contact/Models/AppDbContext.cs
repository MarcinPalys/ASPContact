using Microsoft.EntityFrameworkCore;
using static ASP_Contact.Models.Priority;

namespace ASP_Contact.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }       
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts1.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { id = 1, name = "Andzej",surname="Kowalskiiii",  email = "adam@wsei.edu.pl", phone = "127813268163", dateOfBirth = new DateTime(2000, 10, 10),Created = DateTime.Now,  Priority = Priority.Low },
                new ContactEntity() { id = 2, name = "Ewa", surname = "Nowak", email = "ewa@wsei.edu.pl", phone = "293443823478", dateOfBirth = new DateTime(1999, 8, 10), Created = DateTime.Now, Priority = Priority.High }
            );
        }
    }
}
