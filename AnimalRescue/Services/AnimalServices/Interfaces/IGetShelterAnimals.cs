using AnimalRescue.Models;

namespace AnimalRescue.Services.AnimalServices.Interfaces
{
    public interface IGetShelterAnimals
    {
        public List<AnimalModel> GetAnimals(Guid id);
    }
}
