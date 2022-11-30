using AnimalRescue.Models;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.ShelterServices;
using AnimalRescue.Services.ShelterServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Controllers
{
    public class ShelterController : Controller
    {
        private readonly IAddShelter _addShelter;
        private readonly IGetAllShelters _getAllShelters;
        private readonly IDeleteShelter _deleteShelter;
        private readonly IEditShelter _editShelter;
        private readonly IGetShelterById _getShelterById;

        public ShelterController(IAddShelter addShelter,
                                 IGetAllShelters getAllShelters,
                                 IDeleteShelter deleteShelter,
                                 IEditShelter editShelter,
                                 IGetShelterById getShelterById)
        {
            _addShelter = addShelter;
            _getAllShelters = getAllShelters;
            _deleteShelter = deleteShelter;
            _editShelter = editShelter;
            _getShelterById = getShelterById;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["AllShelters"] = _getAllShelters.GetAllShelters();
            return View();
        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult AddShelter() 
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddShelter(ShelterModel model)
        {
            _addShelter.CreateNewShelter(model);
            return Redirect("/Shelter/Index");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult RemoveShelter(ShelterModel shelterModel) 
        {
            _deleteShelter.DeleteShelter(shelterModel.Id);

            return Redirect("/Shelter/Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditShelter(Guid id)
        {
            var shelter = _getShelterById.GetById(id);

            return View("EditShelter", shelter);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult EditShelter(ShelterModel model)
        {
            _editShelter.EditShelter(model);

            return Redirect("/Shelter/Index");
        }        
    }
}
