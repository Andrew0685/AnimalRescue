using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using AnimalRescueDBModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescue.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IAddFavorite _addFovorite;
        private readonly IGetUserByEmail _getUserByEmail;
        private readonly IGetShelterAnimals _getShelterAnimals;
        private readonly IGetFavoritesModels _getFavoritesModels;
        private readonly IDeleteFavorite _deleteFavorite;

        public FavoritesController(IAddFavorite addFovorite,
                                   IGetUserByEmail getUserByEmail,
                                   IGetShelterAnimals getShelterAnimals,
                                   IGetFavoritesModels getFavoritesModels,
                                   IDeleteFavorite deleteFavorite)
        {
            _addFovorite = addFovorite;
            _getUserByEmail = getUserByEmail;
            _getShelterAnimals = getShelterAnimals;
            _getFavoritesModels = getFavoritesModels;
            _deleteFavorite = deleteFavorite;
        }

        [Authorize(Roles ="user")]
        [HttpPost]
        public IActionResult AddFavorite(AnimalModel animal)
        {
            var animalId = animal.Id;
            var userId = _getUserByEmail.GetUserModel(User.Identity.Name).Id;
            
            _addFovorite.SetFavorite(userId, animalId);

            //var animals = _getShelterAnimals.GetAnimals(animal.ShelterId);
            //ViewData["ShelterAnimals"] = animals;

            return Redirect("/Shelter/Index");
        }

        [Authorize(Roles ="user")]
        [HttpGet]
        public IActionResult DisplayFavorites() 
        {
            var userId = _getUserByEmail.GetUserModel(User.Identity.Name).Id;
            var favorites = _getFavoritesModels.GetFavoriteModelList(userId);

            ViewData["UserFavorites"] = favorites;

            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult DeleteFavorite(FavoriteModel model)
        {
            _deleteFavorite.RemoveFavorite(model.AnimalId);

            return Redirect("/Favorites/DisplayFavorites");
        }
    }
}
