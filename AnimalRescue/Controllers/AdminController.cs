using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AnimalRescue.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IGetUserByEmail _getUserByEmail;

        public AdminController(IGetUserByEmail getUserByEmail)
        {
            _getUserByEmail = getUserByEmail;
        }
        public IActionResult Index()
        {
            var login = User.Identity.Name;

            ViewData["UserProfile"] = _getUserByEmail.GetUserModel(login);

            return View();
        }

        
        //public IActionResult Admin()
        //{
        //    return View();
        //}

        //[Authorize(Roles = "user")]
        //public IActionResult User()
        //{
        //    return View();
        //}        
    }
}
