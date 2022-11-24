using AnimalRescue.Models;

namespace AnimalRescue.Services.UserSevices.Interfaces
{
    public interface IGetAllUsers
    {
        public List<UserModel> GetAllUsers();
    }
}
