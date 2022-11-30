using AnimalRescue.Models;

namespace AnimalRescue.Services.UserSevices.Interfaces
{
    public interface IGetUserByEmail
    {
        public UserModel GetUserModel(string eMail);
    }
}
