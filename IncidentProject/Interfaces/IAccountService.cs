using IncidentData.Models;
using IncidentProject.Models;
using System.Collections.Generic;

namespace IncidentProject.Interfaces
{
    public interface IAccountService: IValidation
    {
        public List<Account> GetAllAccounts();

        public Account GetAccountByName(string name);

        public Account CreateAccount(Account accountModel);

        public Account CreateAccount(MainRequestModel requestModel);

        public Account UpdateAccount(Account account);

        public Account DeleteAccount(string name);
    }
}
