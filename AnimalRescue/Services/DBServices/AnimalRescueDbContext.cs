using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescueDB;

namespace AnimalRescue.Services.DBServices
{
    public class AnimalRescueDbContext : IAnimalRescueDbContext
    {
        public AnimalRescueDBContext animalRescueDBContext { get; set; }
        public AnimalRescueDbContext()
        {
            animalRescueDBContext = new AnimalRescueDBContext();
        }
    }
}
