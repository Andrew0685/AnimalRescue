using AnimalRescue.Models;

namespace AnimalRescue.Services.FavoriteServices.Interfaces
{
    public interface IGetFavoritesModels
    {
        public List<FavoriteModel> GetFavoriteModelList(Guid userId);
    }
}
