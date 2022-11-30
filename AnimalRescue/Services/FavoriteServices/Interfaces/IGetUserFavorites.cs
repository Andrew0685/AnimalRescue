using AnimalRescue.Models;
using AnimalRescueDBModels.Entities;

namespace AnimalRescue.Services.FavoriteServices.Interfaces
{
    public interface IGetUserFavorites
    {
        public List<AnimalUserModel> GetFavorites(Guid userId);
    }
}
