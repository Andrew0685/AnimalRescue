using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.FavoriteServices
{
    public class DeleteFavoriteService : IDeleteFavorite
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public DeleteFavoriteService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RemoveFavorite(Guid animalId)
        {
            var favorite = _dbContext.animalRescueDBContext.AnimalsUsers.FirstOrDefault(f=>f.AnimalId == animalId);

            _dbContext.animalRescueDBContext.AnimalsUsers.Remove(favorite);

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
