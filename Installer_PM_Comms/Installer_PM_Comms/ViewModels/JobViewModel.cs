using Installer_PM_Comms.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Installer_PM_Comms.ViewModels
{
    public class JobViewModel
    {
        public double JobNumber { get; set; }
        public string JobName { get; set; }
        public int ProjectManagerId { get; set; }
        public Project_Manager Project_Manager {get; set;}
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Client> Clients { get; set; }
        public int InstallerId { get; set; }
        public Installer Installer { get; set; }
        public List<Installer> Installers { get; set; }
        public string? Description { get; set; }
        public DateTime? InstallDate { get; set; }
        public bool InstallCompleted { get; set; } = false;
        public string? Notes { get; set; }
        public IFormFile? Blueprints { get; set; }
        public IFormFile? Photos { get; set; }
    }
}
