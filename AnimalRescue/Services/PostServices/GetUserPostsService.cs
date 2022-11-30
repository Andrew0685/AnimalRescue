using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.PostServices
{
    public class GetUserPostsService : IGetUserPosts
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetUserPostsService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<PostModel> GetPosts(Guid userId)
        {
            var userPostsInDb = _dbContext.animalRescueDBContext.Posts.Where(p=>p.UserId == userId);
            var userPosts = new List<PostModel>();

            foreach (var post in userPostsInDb) 
            {
                userPosts.Add(new PostModel
                {
                    Id = post.Id,
                    Type = post.Type,
                    Description = post.Description,
                    Created = post.Created,
                });
            }            

            return userPosts;
        }
    }
}
