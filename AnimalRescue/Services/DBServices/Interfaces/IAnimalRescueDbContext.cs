using AnimalRescueDB;

namespace AnimalRescue.Services.DBServices.Interfaces
{
    public interface IAnimalRescueDbContext
    {
        public AnimalRescueDBContext animalRescueDBContext { get; set; }
    }
}
