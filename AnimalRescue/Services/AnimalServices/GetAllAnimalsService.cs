using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices.Interfaces;

namespace AnimalRescue.Services.AnimalServices
{
    public class GetAllAnimalsService : IGetAllAnimals
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetAllAnimalsService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AnimalModel> GetAllAnimal()
        {
            var animalList = new List<AnimalModel>();
            var animalInDbList = _dbContext.animalRescueDBContext.Animals.ToList();

            foreach (var animal in animalInDbList)
            {
                animalList.Add(new AnimalModel
                {
                    Id = animal.Id,
                    Type = animal.Type,
                    Name = animal.Name,
                    Gender = animal.Gender,
                    Age = animal.Age,
                    Description = animal.Description,
                });
            }

            return animalList;
        }
    }
}
