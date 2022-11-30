using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FileServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.ShelterServices
{
    public class DeleteShelterService : IDeleteShelter
    {
        private readonly IAnimalRescueDbContext _dbContext;
        private readonly IFileDelete _fileDelete;

        public DeleteShelterService(IAnimalRescueDbContext dbContext,
                                    IFileDelete fileDelete) 
        {
            _dbContext = dbContext;
            _fileDelete = fileDelete;
        }
        public void DeleteShelter(Guid shelterId)
        {
            var delitingShelter = _dbContext.animalRescueDBContext.Shelters.FirstOrDefault(x => x.Id == shelterId);
            var shelterAnimals = _dbContext.animalRescueDBContext.Animals.Where(a=>a.ShelterId == shelterId).ToList();            

            foreach (var animal in shelterAnimals) 
            {
                _dbContext.animalRescueDBContext.Animals.Remove(animal);

                var favorites = _dbContext.animalRescueDBContext.AnimalsUsers.Where(f => f.AnimalId == animal.Id).ToList();

                foreach (var item in favorites) 
                {
                    _dbContext.animalRescueDBContext.AnimalsUsers.Remove(item);
                }
            }

            var directoryPath = $"Animals/{shelterId}";

            _fileDelete.RemoveDirectoryWithFile(directoryPath);
            _dbContext.animalRescueDBContext.Shelters.Remove(delitingShelter);
            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
