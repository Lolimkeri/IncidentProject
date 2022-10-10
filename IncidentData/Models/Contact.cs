using System.ComponentModel.DataAnnotations;

namespace IncidentData.Models
{
    public class Contact
    {
        [Key]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Account Account { get; set; }
    }
}
