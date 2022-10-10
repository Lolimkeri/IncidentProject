using IncidentData.Interfaces;
using IncidentData.Models;
using IncidentProject.Exceptions;
using IncidentProject.Interfaces;
using IncidentProject.Models;
using System.Collections.Generic;

namespace IncidentProject.Services
{
    public class IncidentService: IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IAccountService _accountService;

        public IncidentService(IIncidentRepository incidentRepository, IAccountService accountService)
        {
            _incidentRepository = incidentRepository;
            _accountService = accountService;
        }

        public List<Incident> GetAllIncidents()
        {
            return _incidentRepository.GetAll();
        }

        public Incident GetIncidentByName(string name)
        {
            return _incidentRepository.GetByName(name);
        }

        public Incident CreateIncident(Incident incident)
        {
            return _incidentRepository.Insert(incident);
        }

        public Incident CreateIncident(MainRequestModel requestModel)
        {
            var incidentModel = new Incident
            {
                Description = requestModel.Description
            };

            var accountModel = _accountService.GetAccountByName(requestModel.Name);
            if (accountModel == null)
            {
                throw new AccountBadNameException();
            }

            var newIncident = CreateIncident(incidentModel);

            accountModel.Incident = newIncident;

            _accountService.UpdateAccount(accountModel);

            return newIncident;
        }

        public Incident UpdateIncident(Incident incident)
        {
            return _incidentRepository.Update(incident);
        }

        public Incident DeleteIncident(string name)
        {
            return _incidentRepository.Delete(name);
        }

        public bool Validate(MainRequestModel requestModel, out string errorMessage)
        {
            errorMessage = "";

            if (requestModel.Name == null)
            {
                errorMessage = "Incident can`t be created without account";
                return false;
            }

            return true;
        }
    }
}
