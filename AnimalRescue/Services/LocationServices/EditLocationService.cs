using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.LocationServices.Interfaces;

namespace AnimalRescue.Services.LocationServices
{
    public class EditLocationService : IEditLocation
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public EditLocationService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void EditLocation(LocationModel location)
        {
            var editingLocation = _dbContext.animalRescueDBContext.Locations.FirstOrDefault(l=>l.Id == location.Id);
            editingLocation.Area = location.Area;
            editingLocation.District = location.District;
            editingLocation.City = location.City;

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
