using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using AnimalRescueDBModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.FavoriteServices
{
    public class AddFavoriteService : IAddFavorite
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AddFavoriteService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SetFavorite(Guid userId, Guid animalId)
        {
            var transitTable = _dbContext.animalRescueDBContext.AnimalsUsers;
            transitTable.Add(new AnimalUser 
            {
                UserId = userId,
                AnimalId = animalId,
            });
            //user.Animals.Add(animal);

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
