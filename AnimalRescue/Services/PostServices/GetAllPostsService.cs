using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;

namespace AnimalRescue.Services.PostServices
{
    public class GetAllPostsService : IGetAllPosts
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetAllPostsService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<PostModel> GetAllPosts()
        {
            var postsList = new List<PostModel>();
            var postsInDbList = _dbContext.animalRescueDBContext.Posts.ToList();

            foreach (var posts in postsInDbList)
            {
                postsList.Add(new PostModel
                {
                    Id = posts.Id,
                    Type = posts.Type,
                    Description = posts.Description,
                    Created = posts.Created,
                    UserId = posts.UserId,
                    LocationId = posts.LocationId,
                });
            }

            return postsList;
        }
    }
}
