using AnimalRescue.Models;
using AnimalRescue.Services.DBServices;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using AnimalRescueDBModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.FavoriteServices
{
    public class GetFavoriteModelService : IGetFavoritesModels
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetFavoriteModelService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<FavoriteModel> GetFavoriteModelList(Guid userId)
        {
            var favorites = _dbContext.animalRescueDBContext.AnimalsUsers.Where(f => f.UserId == userId).ToList();
            var favoritesModelsList = new List<FavoriteModel>();

            foreach (var item in favorites) 
            {
                

                var animal = _dbContext.animalRescueDBContext.Animals.FirstOrDefault(a => a.Id == item.AnimalId);
                var shelter = _dbContext.animalRescueDBContext.Shelters.FirstOrDefault(s => s.Id == animal.ShelterId);

                favoritesModelsList.Add(new FavoriteModel
                {
                    Type = animal.Type,
                    Name = animal.Name,
                    Gender = animal.Gender,
                    Age = animal.Age,
                    Description = animal.Description,
                    PhotoFileName = animal.FileName,
                    ShelterTitle = shelter.Name,
                    Address = shelter.Address,
                    ShelterId = shelter.Id,
                    AnimalId = animal.Id,
                });
            }

            return favoritesModelsList;
        }
    }
}
