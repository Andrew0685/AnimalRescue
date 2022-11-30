using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AnimalRescue.Services.AnimalServices
{
    public class GetShelterAnimalsService : IGetShelterAnimals
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetShelterAnimalsService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AnimalModel> GetAnimals(Guid shelterId)
        {
            var shelterAnimals = _dbContext.animalRescueDBContext.Animals.Where(a => a.ShelterId == shelterId);
            var animals = new List<AnimalModel>();
            foreach (var animal in shelterAnimals)
            {
                animals.Add(new AnimalModel
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Type = animal.Type,
                    Gender = animal.Gender,
                    Age = animal.Age,
                    Description = animal.Description,
                    PhotoFileName = animal.FileName,
                    ShelterId = shelterId,
                });
            }

            return animals;
        }
    }
}
