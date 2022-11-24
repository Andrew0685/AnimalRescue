using AnimalRescue.Models;

namespace AnimalRescue.Services.PostServices.Interfaces
{
    public interface IAddPost
    {
        public void CreatePost(PostModel post);
    }
}
