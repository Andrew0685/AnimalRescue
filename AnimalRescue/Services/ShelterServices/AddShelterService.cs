using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;
using AnimalRescueDBModels.Entities;

namespace AnimalRescue.Services.ShelterServices
{
    public class AddShelterService : IAddShelter
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AddShelterService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateNewShelter(ShelterModel shelter)
        {
            _dbContext.animalRescueDBContext.Shelters.Add(new Shelter
            {
                Id = Guid.NewGuid(),
                Name = shelter.Name,
                Address = shelter.Address,
            });
            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
