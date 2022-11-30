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
    public class AuthController : Controller
    {
        private readonly IAnimalRescueDbContext _dbContext;
        private readonly IAddUser _createNewUser;

        public AuthController(IAnimalRescueDbContext dbContext,
                              IAddUser createNewUser)
        {
            _dbContext = dbContext;
            _createNewUser = createNewUser;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _dbContext.animalRescueDBContext.Users
                       .SingleOrDefaultAsync(u => u.Email == model.EMail && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.EMail),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            //if (model.ReturnUrl == null)
            //{
            //    model.ReturnUrl = $"/{user.Role}/index";
            //}

            model.ReturnUrl = $"/{user.Role}/index";

            return Redirect(model.ReturnUrl);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            _createNewUser.CreateUser(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

           
            return Redirect("/User/Index");
        }

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
