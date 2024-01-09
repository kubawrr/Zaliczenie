using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ComputerEntity> Computers { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<ComputerShippingCountry> ComputerShippingCountries { get; set; }
        public DbSet<ShippingCountries> ShippingCountries { get; set; }
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "computers.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            string ADMIN_ID = Guid.NewGuid().ToString();   
            string ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "admin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });


            var admin = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN"
            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234567!");
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID,
                });

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address);
            modelBuilder.Entity<ComputerEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Computers)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity()
                {
                    Id = 1,
                    Title = "Company",
                    Nip = "83492384",
                    Regon = "13424234",
                },
                new OrganizationEntity()
                {
                    Id = 2,
                    Title = "Firma",
                    Nip = "2498534",
                    Regon = "0873439249"
                }
        );
            modelBuilder.Entity<ComputerEntity>().HasData(
                new ComputerEntity()
                {
                    Id = 1,
                    Cpu = "Intel i7-7200K",
                    Gpu = "Nvidia GeForce RTX 4090",
                    Name = "Gaming PC",
                    Manufacturer = "Company",
                    OrganizationId = 1,
                },
                 new ComputerEntity()
                 {
                     Id = 2,
                     Cpu = "Intel i7-7200K",
                     Gpu = "Integrated",
                     Name = "Office PC",
                     Manufacturer = "Company",
                     OrganizationId = 2,
                 }
                 );
            
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address)
                .HasData(
                    new { OrganizationEntityId = 1, City = "Kraków", Street = "Św.Filipa 17", PostalCode = "31-150", Region = "małopolska" },
                    new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolska" }
                );

            modelBuilder.Entity<ComputerShippingCountry>()
            .HasKey(sc => new { sc.ShippingId, sc.ComputerId });

            modelBuilder.Entity<ComputerShippingCountry>()
                .HasOne(sc => sc.ShippingCountries)
                .WithMany(s => s.ComputerShippingCountries)
                .HasForeignKey(sc => sc.ShippingId);

            modelBuilder.Entity<ComputerShippingCountry>()
                .HasOne(sc => sc.Computer)
                .WithMany(c => c.ComputerShippingCountries)
                .HasForeignKey(sc => sc.ComputerId);

            modelBuilder.Entity<ShippingCountries>().HasData(
            new ShippingCountries { Id = 1, CountryName = "Poland" },
            new ShippingCountries { Id = 2, CountryName = "Germany" }
          );
            modelBuilder.Entity<ComputerShippingCountry>().HasData(
            new ComputerShippingCountry { ShippingId = 1, ComputerId = 1 },
            new ComputerShippingCountry { ShippingId = 1, ComputerId = 2 },           
            new ComputerShippingCountry { ShippingId = 2, ComputerId = 3 }
            );
        }
    }
}
