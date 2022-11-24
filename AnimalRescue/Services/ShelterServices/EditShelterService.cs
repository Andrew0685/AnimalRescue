using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;

namespace AnimalRescue.Services.ShelterServices
{
    public class EditShelterService : IEditShelter
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public EditShelterService(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void EditShelter(ShelterModel shelter)
        {
            var editingShelter = _dbContext.animalRescueDBContext.Shelters.FirstOrDefault(s=>s.Id == shelter.Id);

            editingShelter.Name = shelter.Name;
            editingShelter.Address = shelter.Address;

            _dbContext.animalRescueDBContext.SaveChanges();
        }
    }
}
