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
            builder.Entity<Job_Installs>().HasOne<Job>(ji => ji.Job).WithMany(j => j.Job_Installs).HasForeignKey(ji => ji.JobId);
            builder.Entity<Job_Installs>().HasOne<Installer>(ji => ji.Installer).WithMany(j => j.Job_Installs).HasForeignKey(ji => ji.InstallerId);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Project Manager", NormalizedName = "PROJECT MANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Installer", NormalizedName = "INSTALLER" });
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
