using AnimalRescue.Models;

namespace AnimalRescue.Services.LocationServices.Interfaces
{
    public interface IAddLocation
    {
        public void CreateLoction(LocationModel locationModel);
    }
}
