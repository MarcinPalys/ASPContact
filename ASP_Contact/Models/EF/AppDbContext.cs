using Microsoft.EntityFrameworkCore;

namespace ASP_Contact.Models.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts  { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)  
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    id = 1,
                    name = "Test",
                    surname = "Test3",
                    email = "dasdasd",
                    phone = "123124123",
                    dateOfBirth = new DateTime(year: 2000, month: 10, day: 3),
                    Priority = Priority.Priority_.Low
                }
            );
        }
    }
}
