using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.LocationServices.Interfaces;
using AnimalRescueDBModels.Entities;

namespace AnimalRescue.Services.LocationServices
{
    public class AddLocationService : IAddLocation
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AddLocationService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateLoction(LocationModel locationModel)
        {
            _dbContext.animalRescueDBContext.Locations.Add(new Location 
            {
                Id = Guid.NewGuid(),
                Area = locationModel.Area,
                District = locationModel.District,
                City = locationModel.City,
            });

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
