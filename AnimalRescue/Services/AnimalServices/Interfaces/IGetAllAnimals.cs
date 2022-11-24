using AnimalRescue.Models;

namespace AnimalRescue.Services.AnimalServices.Interfaces
{
    public interface IGetAllAnimals
    {
        public List<AnimalModel> GetAllAnimal();
    }
}
