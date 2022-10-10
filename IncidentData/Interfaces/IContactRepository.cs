using IncidentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncidentData.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();

        public Contact GetByEmail(string email);

        public Contact Insert(Contact model);

        public Contact Delete(string email);

        public Contact Update(Contact model);

        public void Save();
    }
}
