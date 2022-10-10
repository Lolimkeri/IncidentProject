using IncidentData.Interfaces;
using IncidentData.Models;
using IncidentProject.Interfaces;
using IncidentProject.Models;
using System.Collections.Generic;

namespace IncidentProject.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IContactService _contactService;

        public AccountService(IAccountRepository accountRepository, IContactService contactService)
        {
            _accountRepository = accountRepository;
            _contactService = contactService;
        }

        public List<Account> GetAllAccounts()
        {
            return _accountRepository.GetAll();
        }

        public Account GetAccountByName(string name)
        {
            return _accountRepository.GetByName(name);
        }

        public Account CreateAccount(Account accountModel)
        {
            return _accountRepository.Insert(accountModel);
        }

        public Account CreateAccount(MainRequestModel requestModel)
        {
            var accountModel = new Account
            {
                Name = requestModel.Name
            };

            var contactModel = new Contact
            {
                Email = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };

            var newAccount = CreateAccount(accountModel);

            if (_contactService.GetContactByEmail(contactModel.Email) != null)
            {
                var updatedContact = _contactService.UpdateContact(contactModel);

                if (updatedContact.Account == null)
                {
                    updatedContact.Account = newAccount;

                    _contactService.UpdateContact(updatedContact);
                }
            }
            else
            {
                var newContact = _contactService.CreateContact(requestModel);
                newContact.Account = newAccount;

                _contactService.UpdateContact(newContact);
            }

            return newAccount;
        }

        public Account UpdateAccount(Account account)
        {
            return _accountRepository.Update(account);
        }

        public Account DeleteAccount(string name)
        {
            return _accountRepository.Delete(name);
        }

        public bool Validate(MainRequestModel requestModel, out string errorMessage)
        {
            errorMessage = "";

            if (requestModel.Name == null)
            {
                errorMessage = "Account must have name value";
                return false;
            }

            if (requestModel.Email == null)
            {
                errorMessage = "Account can`t be created without contact";
                return false;
            }

            return true;
        }
    }
}
