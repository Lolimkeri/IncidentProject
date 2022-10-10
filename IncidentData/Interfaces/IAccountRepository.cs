using IncidentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentData.Interfaces
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();

        public Account GetByName(string name);

        public Account Insert(Account model);

        public Account Delete(string name);

        public Account Update(Account model);

        public void Save();
    }
}
