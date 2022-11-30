using AnimalRescue.Exceptions;
using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FileUploadServices.Interfaces;
using AnimalRescue.Services.PostServices.Interfaces;
using AnimalRescue.Services.UserSevices;
using AnimalRescue.Services.UserSevices.Interfaces;
using AnimalRescueDBModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Data;
using System.Security.Claims;

namespace AnimalRescue.Controllers
{
    [Authorize]
    public class PostController : Controller
    {

        private readonly IFileUpload _fileUpload;
        private readonly IGetUserByEmail _getUserByEmail;
        private readonly IAnimalRescueDbContext _dbContext;
        private readonly IAddPost _addPost;
        private readonly IDeletePost _removePost;
        private readonly IGetUserPosts _getUserPosts;
        public string filePath;

        public PostController(IFileUpload fileUpload,
                              IGetUserByEmail getUserByEmail,
                              IAnimalRescueDbContext dbContext,
                              IAddPost addPost,
                              IDeletePost removePost,
                              IGetUserPosts getUserPosts) 
        {
            _fileUpload = fileUpload;
            _getUserByEmail = getUserByEmail;
            _dbContext = dbContext;
            _addPost = addPost;
            _removePost = removePost;
            _getUserPosts = getUserPosts;
        }


        [HttpGet]
        public IActionResult AddPost()
        {
            var eMail = User.Identity.Name;

            ViewData["UserId"] = _getUserByEmail.GetUserModel(eMail).Id;
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddPost(PostModel model) 
        {

            model.Id = Guid.NewGuid();
            var repoPath = $"wwwroot\\Repo\\Posts\\{model.Id}";

            if (model.File != null)
            {
                filePath = await _fileUpload.UploadFileAsync(model.File, repoPath, model.Id.ToString());
            }
            else 
            {
                throw new FileUploadExeption("You have not uploaded an image!!!Please do this!!!");
            }

            model.Type = model.Type;
            model.Description = model.Description;
            model.UserId = model.UserId;

            _addPost.CreatePost(model);

            return Redirect("/Home/Index");

        }

        [Authorize]
        [HttpPost]
        public IActionResult DeletePost(PostModel postModel) 
        {
            _removePost.RemovePost(postModel.Id);

            return Redirect("/Post/DisplayUserPosts");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeletePostFromBoard(PostModel postModel)
        {
            _removePost.RemovePost(postModel.Id);

            return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult DisplayUserPosts() 
        {
            var email = User.Identity.Name;
            var userId = _getUserByEmail.GetUserModel(email).Id;

            ViewData["UserPosts"] = _getUserPosts.GetPosts(userId);

            return View();
        }
    }
}
