using AnimalRescue.Models;

namespace AnimalRescue.Services.ShelterServices.Interfaces
{
    public interface IGetAllShelters
    {
        public List<ShelterModel> GetAllShelters();
    }
}
