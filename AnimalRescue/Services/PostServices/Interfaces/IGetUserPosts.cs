using AnimalRescue.Models;

namespace AnimalRescue.Services.PostServices.Interfaces
{
    public interface IGetUserPosts
    {
        public List<PostModel> GetPosts(Guid userId);
    }
}
