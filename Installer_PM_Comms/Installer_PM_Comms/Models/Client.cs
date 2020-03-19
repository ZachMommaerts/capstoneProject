using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Installer_PM_Comms.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public PhoneAttribute? ContactPhoneNumber { get; set; }
        public EmailAddressAttribute? ContactEmailAddress { get; set; }
    }
}
