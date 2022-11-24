using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.ShelterServices
{
    public class DeleteShelterService : IDeleteShelter
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public DeleteShelterService(IAnimalRescueDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public void DeleteShelter(Guid id)
        {
            var delitingShelter = _dbContext.animalRescueDBContext.Shelters.FirstOrDefault(x => x.Id == id);
            _dbContext.animalRescueDBContext.Shelters.Remove(delitingShelter);
            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
