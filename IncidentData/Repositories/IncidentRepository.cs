using IncidentData.Interfaces;
using IncidentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncidentData.Repositories
{
    public class IncidentRepository: IIncidentRepository, IDisposable
    {
        protected readonly DataContext Context;

        public IncidentRepository(DataContext context)
        {
            Context = context;
        }

        public List<Incident> GetAll()
        {
            return Context.Set<Incident>().ToList();
        }

        public Incident GetByName(string name)
        {
            return Context.Set<Incident>().Find(name);
        }

        public Incident Insert(Incident model)
        {
            if (GetByName(model.Name) != null)
            {
                throw new ArgumentException("Incident with this name already exists.");
            }

            var newModelDbEntity = Context.Set<Incident>().Add(model);

            Save();

            return newModelDbEntity.Entity;
        }

        public Incident Delete(string name)
        {
            var model = GetByName(name);
            var newModelDbEntity = Context.Set<Incident>().Remove(model);

            Save();

            return newModelDbEntity.Entity;
        }

        public Incident Update(Incident model)
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
