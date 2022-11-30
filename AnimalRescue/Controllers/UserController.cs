using AnimalRescue.Models;
using AnimalRescue.Services.UserSevices;
using AnimalRescue.Services.UserSevices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AnimalRescue.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IGetUserByEmail _getUserByEmail;
        private readonly IEditUser _editUser;
        private readonly IGetAllUsers _getAllUsers;
        private readonly IDeleteUser _deleteUser;

        public UserController(IGetUserByEmail getUserByEmail,
                              IEditUser editUser,
                              IGetAllUsers getAllUsers,
                              IDeleteUser deleteUser)
        {
            _getUserByEmail = getUserByEmail;
            _editUser = editUser;
            _getAllUsers = getAllUsers;
            _deleteUser = deleteUser;
        }

        [Authorize(Roles = "user")]
        public IActionResult Index()
        {
            var login = User.Identity.Name;

            ViewData["UserProfile"] = _getUserByEmail.GetUserModel(login);

            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult EditUserProperties(UserModel user) 
        {
            _editUser.EditUser(user);

            return Redirect("/User/Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult DisplayUsers() 
        {
            ViewData["AllUsersList"] = _getAllUsers.GetAllUsers();

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DeleteUser(UserModel userModel) 
        {
            _deleteUser.DeleteUser(userModel.Id);

            return Redirect("/User/DisplayUsers");
        }
    }
}
