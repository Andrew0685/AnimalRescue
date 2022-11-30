using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FileServices.Interfaces;

namespace AnimalRescue.Services.AnimalServices
{
    public class DeleteAnimalService : IDeleteAnimal
    {
        private readonly IAnimalRescueDbContext _dbContext;
        private readonly IFileDelete _fileDelete;

        public DeleteAnimalService(IAnimalRescueDbContext dbContext,
                                   IFileDelete fileDelete)
        {
            _dbContext = dbContext;
            _fileDelete = fileDelete;
        }
        public void DeleteAnimal(AnimalModel animalModel)
        {
            var delitingAnimal = _dbContext.animalRescueDBContext.Animals
                                    .FirstOrDefault(a=>a.Id == animalModel.Id);
            var animalFavorit = _dbContext.animalRescueDBContext.AnimalsUsers
                                    .Where(f=>f.AnimalId == animalModel.Id).ToList();

            foreach (var animal in animalFavorit) 
            {
                _dbContext.animalRescueDBContext.AnimalsUsers.Remove(animal);
            }

            var animalModelForRemoveFile = new AnimalModel
            {
                Id = delitingAnimal.Id,
                ShelterId = delitingAnimal.ShelterId,
                PhotoFileName = delitingAnimal.FileName,
            };

            _fileDelete.RemoveFile(animalModelForRemoveFile);

            _dbContext.animalRescueDBContext.Animals.Remove(delitingAnimal);

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
