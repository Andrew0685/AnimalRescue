using AnimalRescue.Exceptions;
using AnimalRescue.Models;
using AnimalRescue.Services.DBServices;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using AnimalRescueDBModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnimalRescue.Services.UserSevices
{
    public class AddUserService : IAddUser
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AddUserService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public void CreateUser(UserModel user)
        {
            var existUsers = _dbContext.animalRescueDBContext.Users.FirstOrDefault(u=>u.Email == user.Email);

            if (existUsers == null)
            {
                _dbContext.animalRescueDBContext.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Email = user.Email,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role,
                });
                _dbContext.animalRescueDBContext.SaveChanges();
            }
            else 
            {
                throw new ExistUserExeption("Such user is already exists!!!");
            }
        }
    }    
}
