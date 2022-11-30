using AnimalRescue.Models;

namespace AnimalRescue.Services.ShelterServices.Interfaces
{
    public interface IGetShelterById
    {
        public ShelterModel GetById(Guid id);
    }
}
