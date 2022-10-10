using IncidentData.Interfaces;
using IncidentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncidentData.Repositories
{
    public class ContactRepository: IContactRepository, IDisposable
    {
        protected readonly DataContext Context;

        public ContactRepository(DataContext context)
        {
            Context = context;
        }

        public List<Contact> GetAll()
        {
            return Context.Set<Contact>().ToList();
        }

        public Contact GetByEmail(string email)
        {
            return Context.Set<Contact>().Find(email);
        }

        public Contact Insert(Contact model)
        {
            var newModelDbEntity = Context.Set<Contact>().Add(model);
            Contact newModel = newModelDbEntity.Entity;

            Save();

            return newModel;
        }

        public Contact Delete(string email)
        {
            var model = GetByEmail(email);
            var newModelDbEntity = Context.Set<Contact>().Remove(model);

            Save();

            return newModelDbEntity.Entity;
        }

        public Contact Update(Contact model)
        {
            if (model.Email == default)
            {
                throw new ArgumentException("Can`t update model without primary key value.");
            }

            var oldEntity = GetByEmail(model.Email);

            Context.Entry(oldEntity).CurrentValues.SetValues(model);

            Save();

            return GetByEmail(model.Email);
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
