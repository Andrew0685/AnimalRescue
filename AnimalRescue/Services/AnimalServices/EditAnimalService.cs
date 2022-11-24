using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices.Interfaces;

namespace AnimalRescue.Services.AnimalServices
{
    public class EditAnimalService : IEditAnimal
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public EditAnimalService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void EditAnimal(AnimalModel animal)
        {
            var editingAnimal = _dbContext.animalRescueDBContext.Animals.FirstOrDefault(a=>a.Id == animal.Id);
            editingAnimal.Type = animal.Type;
            editingAnimal.Name = animal.Name;
            editingAnimal.Gender = animal.Gender;
            editingAnimal.Age = animal.Age;
            editingAnimal.Description = animal.Description;

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
