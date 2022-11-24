using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.UserSevices
{
    public class DeleteUserService : IDeleteUser
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public DeleteUserService(IAnimalRescueDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public void DeleteUser(Guid id)
        {
            var delitingUser = _dbContext.animalRescueDBContext.Users.FirstOrDefault(u=>u.Id == id);
            _dbContext.animalRescueDBContext.Users.Remove(delitingUser);
            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
