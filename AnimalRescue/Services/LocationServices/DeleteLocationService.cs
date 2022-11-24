using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.LocationServices.Interfaces;

namespace AnimalRescue.Services.LocationServices
{
    public class DeleteLocationService : IDeleteLocation
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public DeleteLocationService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteLocation(Guid id)
        {
            var delitingLocation = _dbContext.animalRescueDBContext.Locations.FirstOrDefault(l=>l.Id == id);
            _dbContext.animalRescueDBContext.Locations.Remove(delitingLocation);

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
