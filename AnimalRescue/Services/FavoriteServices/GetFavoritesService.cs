using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.FavoriteServices
{
    public class GetFavoritesService : IGetUserFavorites
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetFavoritesService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AnimalUserModel> GetFavorites(Guid userId)
        {
            var animalUser = _dbContext.animalRescueDBContext.AnimalsUsers.Where(a=>a.UserId == userId);
            var favoritesConnects = new List<AnimalUserModel>();

            foreach (var item in animalUser) 
            {
                favoritesConnects.Add(new AnimalUserModel
                {
                    UserId = userId,
                    AnimalId = item.AnimalId,
                });
            }

            return favoritesConnects;
        }
    }
}
