using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IncidentData.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }

        public Incident Incident { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
