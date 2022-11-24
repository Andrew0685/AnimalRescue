using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AnimalRescue.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public AdminController(IAnimalRescueDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "user")]
        public IActionResult User()
        {
            return View();
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
                       .SingleOrDefaultAsync(u=>u.Email == model.EMail && u.Password == model.Password);

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

            return Redirect(model.ReturnUrl);
        }

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
