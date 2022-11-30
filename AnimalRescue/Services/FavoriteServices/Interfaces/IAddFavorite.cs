namespace AnimalRescue.Services.FavoriteServices.Interfaces
{
    public interface IAddFavorite
    {
        public void SetFavorite(Guid userId, Guid animalId);
    }
}
