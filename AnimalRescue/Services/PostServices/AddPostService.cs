using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;
using AnimalRescueDBModels.Entities;

namespace AnimalRescue.Services.PostServices
{
    public class AddPostService : IAddPost
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AddPostService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePost(PostModel post)
        {
            _dbContext.animalRescueDBContext.Posts.Add(new Post 
            {
                Id = post.Id,
                Type = post.Type,
                Description = post.Description,
                Created = DateTime.Now,
                UserId = post.UserId,
            });

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
