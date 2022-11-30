using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FileServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;

namespace AnimalRescue.Services.PostServices
{
    public class DeletePostService : IDeletePost
    {
        private readonly IAnimalRescueDbContext _dbContext;
        private readonly IFileDelete _fileDelete;

        public DeletePostService(IAnimalRescueDbContext dbContext,
                                 IFileDelete fileDelete)
        {
            _dbContext = dbContext;
            _fileDelete = fileDelete;
        }
     
        public void RemovePost(Guid id)
        {
            var delitingPost = _dbContext.animalRescueDBContext.Posts.FirstOrDefault(p => p.Id == id);
            _dbContext.animalRescueDBContext.Posts.Remove(delitingPost);

            var directoryPath = $"Posts/{id}";

            _fileDelete.RemoveDirectoryWithFile(directoryPath);
            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
