using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;

namespace AnimalRescue.Services.PostServices
{
    public class DeletePost : IDeletePost
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public DeletePost(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        void IDeletePost.DeletePost(Guid id)
        {
            var delitingPost = _dbContext.animalRescueDBContext.Posts.FirstOrDefault(p => p.Id == id);
            _dbContext.animalRescueDBContext.Posts.Remove(delitingPost);

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
