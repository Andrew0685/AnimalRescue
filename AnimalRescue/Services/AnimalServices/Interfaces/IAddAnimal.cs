using AnimalRescue.Models;

namespace AnimalRescue.Services.AnimalServices.Interfaces
{
    public interface IAddAnimal
    {
        public void CreateAnimal(AnimalModel animal);
    }
}
