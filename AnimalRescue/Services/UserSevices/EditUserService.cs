using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.UserSevices
{
    public class EditUserService : IEditUser
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public EditUserService(IAnimalRescueDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
       
        public void EditUser(UserModel user)
        {
            var changingUser = _dbContext.animalRescueDBContext.Users.FirstOrDefault(u => u.Id == user.Id);
            changingUser.Email = user.Email;
            changingUser.Password = user.Password;
            changingUser.LastName = user.LastName;
            changingUser.FirstName = user.FirstName;

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
