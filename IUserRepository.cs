using ParksApi.Models;

namespace ParksApi;

public interface IUserRepository
{
    UserDTO GetUser(UserModel userMode);
}