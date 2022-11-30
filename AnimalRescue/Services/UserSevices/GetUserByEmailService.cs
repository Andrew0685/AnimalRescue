using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.UserSevices
{
    public class GetUserByEmailService : IGetUserByEmail
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetUserByEmailService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserModel GetUserModel(string eMail)
        {
            var user = _dbContext.animalRescueDBContext.Users.FirstOrDefault(u=>u.Email == eMail);
            var userModel = new UserModel 
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return userModel;
        }
    }
}
