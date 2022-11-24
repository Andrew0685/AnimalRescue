using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;

namespace AnimalRescue.Services.PostServices
{
    public class EditPostService : IEditPost
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public EditPostService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void EditPost(PostModel post)
        {
            var editingPost = _dbContext.animalRescueDBContext.Posts.FirstOrDefault(p => p.Id == post.Id);
            editingPost.Type = post.Type;
            editingPost.Description = post.Description;
            editingPost.Created = DateTime.Now;

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
