using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Installer_PM_Comms.Models
{
    public class Job_Installs
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Installer")]
        public int? InstallerId { get; set; }
        public Installer Installer { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
