using AnimalRescue.Models;

namespace AnimalRescue.Services.UserSevices.Interfaces
{
    public interface IAddUser
    {
        public void CreateUser(UserModel user);
    }
}
