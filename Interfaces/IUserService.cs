using WEBPROJECT2.Models;

namespace WEBPROJECT2.Interfaces
{
    public interface IUserService
    {
        Task<string> createUser(string username, string password, string passwordAgain);

        Task<Tokens> login(string username, string password);
    }
}