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
            var chengingUser = _dbContext.animalRescueDBContext.Users.FirstOrDefault(u => u.Id == user.Id);
            chengingUser.Email = user.Email;
            chengingUser.Password = user.Password;
            chengingUser.LastName = user.LastName;
            chengingUser.FirstName = user.FirstName;

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
