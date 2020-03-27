using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Installer_PM_Comms.Models;

namespace Installer_PM_Comms.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Job_Installs>().HasKey(ji => new { ji.JobId, ji.InstallerId });
            builder.Entity<Job_Installs>().HasOne<Job>(ji => ji.Job).WithMany(j => j.Job_Installs).HasForeignKey(ji => ji.JobId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Job_Installs>().HasOne<Installer>(ji => ji.Installer).WithMany(j => j.Job_Installs).HasForeignKey(ji => ji.InstallerId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Project Manager", NormalizedName = "PROJECT MANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Installer", NormalizedName = "INSTALLER" });

            builder.Entity<Job>().HasData(
                new Job { Id = 1, ClientId = 1, JobNumber = 247, JobName = "Restaurant Rail", Description = "new hand rail for downtown restaurant", InstallDate = DateTime.Parse("03-27-2020") },
                new Job { Id = 2, ClientId = 2, JobNumber = 768, JobName = "Residential Fence", Description = "new residential fence in west allis", InstallDate = DateTime.Parse("03-27-2020") },
                new Job { Id = 3, ClientId = 3, JobNumber = 134, JobName = "Stair Rail Remodel", Description = "remodel stair rail 12inches", InstallDate = DateTime.Parse("03-27-2020") },
                new Job { Id = 4, ClientId = 4, JobNumber = 318, JobName = "Bar construction", Description = "new bar rail interior", InstallDate = DateTime.Parse("03-27-2020") }
                );

            builder.Entity<Client>().HasData(
                new Client { Id = 1, AddressId = 1, CompanyName = "Hungry Sumo", ContactName = "jenny smith", ContactPhoneNumber = "569-2341", ContactEmailAddress = "jsmith@gmail.com" },
                new Client { Id = 2, AddressId = 2, ContactName = "Rodney Herrington", ContactPhoneNumber = "567-3391", ContactEmailAddress = "rodh@gmail.com" },
                new Client { Id = 3, AddressId = 3, CompanyName = "the blue circle", ContactName = "Jeff Griswold", ContactPhoneNumber = "490-5806", ContactEmailAddress = "bluecircle@gmail.com" },
                new Client { Id = 4, AddressId = 4, CompanyName = "sports 'n drinks", ContactName = "rachel stamford", ContactPhoneNumber = "490-6317", ContactEmailAddress = "rachelstam@gmail.com" }
                );

            builder.Entity<Address>().HasData(
               new Address { Id = 1, StreetName = "329 e pleasant st", City = "oconomowoc", State = "wi", ZipCode = 53066 },
               new Address { Id = 2, StreetName = "2100 n kilian pl", City = "milwaukee", State = "wi", ZipCode = 53212 },
               new Address { Id = 3, StreetName = "1427 s 75th st", City = "west allis", State = "wi", ZipCode = 53214 },
               new Address { Id = 4, StreetName = "1105 57th st", City = "kenosha", State = "wi", ZipCode = 53140 },
               new Address { Id = 5, StreetName = "3880 w milwaukee rd", City = "milwaukee", State = "wi", ZipCode = 53208 }
               );

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Installer> Installers { get; set; }
        public DbSet<Project_Manager> Project_Managers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Job_Installs> Job_Installs { get; set; }
    }
}
