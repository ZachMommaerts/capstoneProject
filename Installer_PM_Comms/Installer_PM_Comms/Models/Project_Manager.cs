using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Installer_PM_Comms.Models
{
    public class Project_Manager
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")] 
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public PhoneAttribute? PhoneNumber { get; set; }
        public EmailAddressAttribute? EmailAddress { get; set; }
    }
}
