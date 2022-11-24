using AnimalRescue.Models;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.ShelterServices.Interfaces;

namespace AnimalRescue.Services.ShelterServices
{
    public class GetAllSheltersServiceI : IGetAllShelters
    {
        private readonly IAnimalRescueDbContext _dbContext;

        public GetAllSheltersServiceI(IAnimalRescueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ShelterModel> GetAllShelters()
        {
            var sheltesList = new List<ShelterModel>();
            var sheltesInDbList = _dbContext.animalRescueDBContext.Shelters.ToList();

            foreach (var shelter in sheltesInDbList)
            {
                sheltesList.Add(new ShelterModel
                {
                    Id = shelter.Id,
                    Name = shelter.Name,
                    Address = shelter.Address,
                });
            }

            return sheltesList;
        }
    }
}
