using AnimalRescue.Exceptions;
using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using AnimalRescue.Services.FileUploadServices.Interfaces;
using AnimalRescue.Services.UserSevices.Interfaces;
using AnimalRescueDBModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescue.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IGetShelterAnimals _getShelterAnimals;
        private readonly IAddAnimal _addAnimal;
        private readonly IFileUpload _fileUpload;
        private readonly IGetUserByEmail _getUserByEmail;
        private readonly IGetUserFavorites _getUserFavorites;
        private readonly IDeleteAnimal _deleteAnimal;
        public string filePath;

        public AnimalController(IGetShelterAnimals getShelterAnimals,
                                IAddAnimal addAnimal,
                                IFileUpload fileUpload,
                                IGetUserByEmail getUserByEmail,
                                IGetUserFavorites getUserFavorites,
                                IDeleteAnimal deleteAnimal)
        {
            _getShelterAnimals = getShelterAnimals;
            _addAnimal = addAnimal;
            _fileUpload = fileUpload;
            _getUserByEmail = getUserByEmail;
            _getUserFavorites = getUserFavorites;
            _deleteAnimal = deleteAnimal;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DisplayShelterPets(ShelterModel shelter)
        {
            if (User.Identity.IsAuthenticated) 
            {
                var user = _getUserByEmail.GetUserModel(User.Identity.Name);
                var favoritesList = _getUserFavorites.GetFavorites(user.Id);

                ViewData["SelectedUserFavorites"] = favoritesList;
            }

            var animals = _getShelterAnimals.GetAnimals(shelter.Id);
            ViewData["ShelterAnimals"] = animals;

            return View();
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult AddPet(ShelterModel shelter) 
        {
            ViewData["ShelterId"] = shelter.Id.ToString();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddPet(AnimalModel animal)
        {
            var repoPath = $"wwwroot\\Repo\\Animals\\{animal.ShelterId}";

            if (animal.File != null)
            {
                filePath = await _fileUpload.UploadFileAsync(animal.File, repoPath, animal.Id.ToString());
            }
            else
            {
                throw new FileUploadExeption("You have not uploaded an image!!!Please do this!!!");
            }
            
            animal.Id = Guid.NewGuid();
            animal.PhotoFileName = $"{animal.Id}{Path.GetExtension(animal.File.FileName)}";

            _addAnimal.CreateAnimal(animal);
            
            return Redirect("/Shelter/Index");
        }


        public IActionResult DeleteAnimal(AnimalModel animalModel) 
        {
            _deleteAnimal.DeleteAnimal(animalModel);

            return Redirect("/Shelter/Index");
        }
    }
}
