using IncidentData.Interfaces;
using IncidentData.Models;
using IncidentProject.Interfaces;
using IncidentProject.Models;
using System.Collections.Generic;

namespace IncidentProject.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetContactByEmail(string email)
        {
            return _contactRepository.GetByEmail(email);
        }

        public Contact CreateContact(Contact contactModel)
        {
            return _contactRepository.Insert(contactModel);
        }

        public Contact CreateContact(MainRequestModel requestModel)
        {
            var contactModel = new Contact
            {
                Email = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };

            return CreateContact(contactModel);
        }

        public Contact UpdateContact(Contact contact)
        {
            return _contactRepository.Update(contact);
        }

        public Contact DeleteContact(string email)
        {
            return _contactRepository.Delete(email);
        }

        public bool Validate(MainRequestModel requestModel, out string errorMessage)
        {
            errorMessage = "";

            if (requestModel.Email == null)
            {
                errorMessage = "Contact must have email value";
                return false;
            }

            return true;
        }
    }
}
