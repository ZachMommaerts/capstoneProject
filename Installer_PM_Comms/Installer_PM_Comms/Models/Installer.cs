using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Installer_PM_Comms.Models
{
    public class Installer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? ContactPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? ContactEmailAddress { get; set; }
        public IList<Job_Installs> Job_Installs { get; set; }
    }
}
