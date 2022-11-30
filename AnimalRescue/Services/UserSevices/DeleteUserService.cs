using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FileServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;

namespace AnimalRescue.Services.UserSevices
{
    public class DeleteUserService : IDeleteUser
    {
        private readonly IAnimalRescueDbContext _dbContext;
        private readonly IFileDelete _fileDelete;

        public DeleteUserService(IAnimalRescueDbContext dbContext,
                                 IFileDelete fileDelete) 
        {
            _dbContext = dbContext;
            _fileDelete = fileDelete;
        }
        public void DeleteUser(Guid id)
        {
            var delitingUser = _dbContext.animalRescueDBContext.Users.FirstOrDefault(u=>u.Id == id);
            var userPosts = _dbContext.animalRescueDBContext.Posts.Where(p => p.UserId == id).ToList();
            var favoritesOfUser = _dbContext.animalRescueDBContext.AnimalsUsers.Where(u => u.UserId == id).ToList();

            foreach (var item in userPosts) 
            {
                var directoryPath = $"Posts/{item.Id}";
                _fileDelete.RemoveDirectoryWithFile(directoryPath);

                _dbContext.animalRescueDBContext.Posts.Remove(item);

            }
            foreach (var item in favoritesOfUser)
            { 
                _dbContext.animalRescueDBContext.AnimalsUsers.Remove(item);
            }

            _dbContext.animalRescueDBContext.Users.Remove(delitingUser);
            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
