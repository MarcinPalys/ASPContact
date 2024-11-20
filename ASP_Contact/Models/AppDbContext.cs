using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static ASP_Contact.Models.Priority;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ASP_Contact.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "contacts1.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={DbPath}");           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString(); 

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            },
            new IdentityRole
            {
                Name = "user",
                NormalizedName = "user",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            }
            );

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADAM@WSEI.EDU.PL"
            };

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "jakub@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "user",
                NormalizedEmail = "JAKUB@WSEI.EDU.PL"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
            user.PasswordHash = ph.HashPassword(user, "qwerty123456");

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });
            
            modelBuilder.Entity<ContactEntity>()
                .HasOne<OrganizationEntity>(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>()
                .ToTable("organizations")
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 101,
                        Name = "WSEI",
                        NIP = "283792834",
                        REGON = "2837294234"
                    },
                    new OrganizationEntity()
                    {
                        Id = 102,
                        Name = "PKP",
                        NIP = "283792834",
                        REGON = "2837294234"
                    }
                );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(organization => organization.Address)
                .HasData(
                    new { OrganizationEntityId = 101, City = "Kraków", Street = "św. Filipa 17" },
                    new { OrganizationEntityId = 102, City = "Warszawa", Street = "Dworcowa 9" }
                );

            modelBuilder.Entity<ContactEntity>()
                .HasData(
                    new ContactEntity()
                    {
                        id = 1,
                        name = "Adam",
                        surname = "Kowal",
                        email = "adam@wsei.edu.pl",
                        phone = "123456789",
                        dateOfBirth = new(2000, 10, 10),
                        Created = DateTime.Now,
                        Priority = Priority.Low,
                        OrganizationId = 101
                    },
                    new ContactEntity()
                    {
                        id = 2,
                        name = "Adam",
                        surname = "Kowal",
                        email = "adam@wsei.edu.pl",
                        phone = "123456789",
                        dateOfBirth = new(2000, 10, 10),
                        Created = DateTime.Now,
                        Priority = Priority.Normal,
                        OrganizationId = 102
                    }
                );
        }
    }
}
