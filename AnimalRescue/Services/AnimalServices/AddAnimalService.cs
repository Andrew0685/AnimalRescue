using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescueDBModels.Entities;

namespace AnimalRescue.Services.AnimalServices
{
    public class AddAnimalService : IAddAnimal
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AddAnimalService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateAnimal(AnimalModel animal)
        {
            _dbContext.animalRescueDBContext.Animals.Add(new Animal 
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
                Gender = animal.Gender,
                Age = animal.Age,
                Description = animal.Description,
                ShelterId = animal.ShelterId,
                FileName = animal.PhotoFileName,
            });

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
