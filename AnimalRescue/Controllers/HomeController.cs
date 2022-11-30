using AnimalRescue.Models;
using AnimalRescue.Services.PostServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimalRescue.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAllPosts _getPosts;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IGetAllPosts getPosts)
        {
            _getPosts = getPosts;
        }

        public IActionResult Index()
        {
            //ViewBag.Name = User.Identity.Name;
            //ViewBag.IsAuthenticated = User.Identity?.IsAuthenticated;

            var postsLostType = _getPosts.GetPostsLostType();
            var postsFoundType = _getPosts.GetPostsFoundType();

            ViewData["LostTypePosts"] = postsLostType;
            ViewData["FoundTypePosts"] = postsFoundType;

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}