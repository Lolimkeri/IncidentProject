using IncidentData.Models;
using System.Collections.Generic;

namespace IncidentData.Interfaces
{
    public interface IIncidentRepository
    {
        public List<Incident> GetAll();

        public Incident GetByName(string name);

        public Incident Insert(Incident model);

        public Incident Delete(string name);

        public Incident Update(Incident model);

        public void Save();
    }
}
