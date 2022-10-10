using IncidentProject.Models;

namespace IncidentProject.Interfaces
{
    public interface IValidation
    {
        public bool Validate(MainRequestModel requestModel, out string errorMessage);
    }
}
