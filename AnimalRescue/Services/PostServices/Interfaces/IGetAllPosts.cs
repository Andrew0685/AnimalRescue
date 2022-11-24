using AnimalRescue.Models;

namespace AnimalRescue.Services.PostServices.Interfaces
{
    public interface IGetAllPosts
    {
        public List<PostModel> GetAllPosts();
    }
}
