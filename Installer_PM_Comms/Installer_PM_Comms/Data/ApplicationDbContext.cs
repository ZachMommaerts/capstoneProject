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

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Project Manager", NormalizedName = "PROJECT MANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Installer", NormalizedName = "INSTALLER" });
        }

        public DbSet<Installer_PM_Comms.Models.Admin> Admin { get; set; }

        public DbSet<Installer_PM_Comms.Models.Installer> Installer { get; set; }

        public DbSet<Installer_PM_Comms.Models.Project_Manager> Project_Manager { get; set; }
    }
}
