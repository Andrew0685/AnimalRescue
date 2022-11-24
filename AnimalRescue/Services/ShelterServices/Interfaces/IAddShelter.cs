using AnimalRescue.Models;

namespace AnimalRescue.Services.ShelterServices.Interfaces
{
    public interface IAddShelter
    {
        public void CreateNewShelter(ShelterModel shelter);
    }
}
