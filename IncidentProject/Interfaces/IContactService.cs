using IncidentData.Models;
using IncidentProject.Models;
using System.Collections.Generic;

namespace IncidentProject.Interfaces
{
    public interface IContactService: IValidation
    {
        public List<Contact> GetAllContacts();

        public Contact GetContactByEmail(string email);

        public Contact CreateContact(Contact contactModel);

        public Contact CreateContact(MainRequestModel requestModel);

        public Contact UpdateContact(Contact contact);

        public Contact DeleteContact(string email);
    }
}
