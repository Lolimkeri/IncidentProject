using IncidentData.Models;
using IncidentProject.Models;
using System.Collections.Generic;

namespace IncidentProject.Interfaces
{
    public interface IIncidentService: IValidation
    {
        public List<Incident> GetAllIncidents();

        public Incident GetIncidentByName(string name);

        public Incident CreateIncident(Incident incident);

        public Incident CreateIncident(MainRequestModel requestModel);

        public Incident UpdateIncident(Incident incident);

        public Incident DeleteIncident(string name);
    }
}
