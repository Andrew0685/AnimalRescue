using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.ShelterServices
{
    public class GetShelterByIdService : IGetShelterById
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetShelterByIdService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ShelterModel GetById(Guid id)
        {
            var shelterDbModel = _dbContext.animalRescueDBContext.Shelters.FirstOrDefault(x => x.Id == id);
            var shelter = new ShelterModel 
            {
                Id = id,
                Name = shelterDbModel.Name,
                Address = shelterDbModel.Address,
            };

            return shelter;
        }
    }
}
