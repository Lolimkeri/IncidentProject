using IncidentData.Interfaces;
using IncidentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncidentData.Repositories
{
    public class AccountRepository: IAccountRepository, IDisposable
    {
        protected readonly DataContext Context;

        public AccountRepository(DataContext context)
        {
            Context = context;
        }

        public List<Account> GetAll()
        {
            return Context.Set<Account>().ToList();
        }

        public Account GetByName(string name)
        {
            return Context.Set<Account>().Find(name);
        }

        public Account Insert(Account model)
        {
            if (GetByName(model.Name) != null)
            {
                throw new ArgumentException("Account with this name already exists.");
            }

            var newModelDbEntity = Context.Set<Account>().Add(model);

            Save();

            return newModelDbEntity.Entity;
        }

        public Account Delete(string name)
        {
            var model = GetByName(name);
            var newModelDbEntity = Context.Set<Account>().Remove(model);

            Save();

            return newModelDbEntity.Entity;
        }

        public Account Update(Account model)
        {
            if (model.Name == default)
            {
                throw new ArgumentException("Can`t update model without primary key value.");
            }

            var oldEntity = GetByName(model.Name);

            Context.Entry(oldEntity).CurrentValues.SetValues(model);

            Save();

            return GetByName(model.Name);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
