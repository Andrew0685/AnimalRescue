using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices.Interfaces;

namespace AnimalRescue.Services.AnimalServices
{
    public class DeleteAnimalService : IDeleteAnimal
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public DeleteAnimalService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAnimal(Guid id)
        {
            var delitingAnimal = _dbContext.animalRescueDBContext.Animals.FirstOrDefault(a=>a.Id == id);
            _dbContext.animalRescueDBContext.Animals.Remove(delitingAnimal);

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
