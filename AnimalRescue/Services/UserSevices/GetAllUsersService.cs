using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Services.UserSevices
{
    public class GetAllUsersService:IGetAllUsers
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetAllUsersService(IAnimalRescueDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public List<UserModel> GetAllUsers()
        {
            var usersList = new List<UserModel>();
            var usersInDbList = _dbContext.animalRescueDBContext.Users.ToList();

            foreach (var user in usersInDbList) 
            {
                usersList.Add(new UserModel 
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role,
                });
            }

            return usersList;
        }
    }
}
