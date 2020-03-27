using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Installer_PM_Comms.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Project_Manager")]
        public int? ProjectManagerId { get; set; }
        public Project_Manager Project_Manager { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public string JobName { get; set; }
        public double JobNumber { get; set; }
        public string? Blueprints { get; set; }
        public string? Photos { get; set; }
        public string? Description { get; set; }
        public DateTime? InstallDate { get; set; }
        public bool InstallCompleted { get; set; } = false;
        public DateTime? ClockInOne { get; set; }
        public DateTime? ClockOutOne { get; set; }
        public string? Notes { get; set; }
        public bool Completed { get; set; } = false;
        public DateTime? CompletionDate { get; set; }
        public IList<Job_Installs> Job_Installs { get; set; }
    }
}
