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
                });
            }

            return postsList;
        }

        public List<PostModel> GetPostsLostType() 
        {
            var allPosts = GetAllPosts();
            List<PostModel> postsLostType = new List<PostModel>();

            foreach (var post in allPosts) 
            {
                if (post.Type == "lost") 
                {
                    postsLostType.Add(post);
                }
            }

            return postsLostType;
        }

        public List<PostModel> GetPostsFoundType()
        {
            var allPosts = GetAllPosts();
            List<PostModel> postsFoundType = new List<PostModel>();

            foreach (var post in allPosts)
            {
                if (post.Type == "found")
                {
                    postsFoundType.Add(post);
                }
            }

            return postsFoundType;
        }
    }
}
