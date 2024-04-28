using WEBPROJECT2.Interfaces;
using WEBPROJECT2.Models;

namespace WEBPROJECT2.Services
{
    public class UserService : IUserService
    {
        public IRepository<User> _userRepos;

        public IRepository<Tokens> _tokenRepos;
        public UserService(IRepository<User> userRepos, IRepository<Tokens> tokenRepos)
        {
            _userRepos = userRepos;
            _tokenRepos = tokenRepos;
        }

        public Task<string> createUser(string username, string password, string passwordAgain)
        {
            if(username == null || password == null || passwordAgain == null) throw new ArgumentNullException("Plese fill in the blanks completely!");

            if(!password.Equals(passwordAgain)) throw new Exception("Please use the same passwords.");

            User newUser = new User
            {
                UserName = username,
                Password = password,
            };

            _userRepos.Addition(newUser);

            User user = _userRepos.Get(user => user.UserName == username && user.Password == password);

            Tokens token = new Tokens
            {
                userID = user.ID, 
                Token = null,
                ExpiryTime = DateTime.Now
            };

            _tokenRepos.Addition(token);

            return Task.FromResult("New user is added succesfully.");
        }

        public Task<Tokens> login(string username, string password)
        {
            if (username == null || password == null) throw new ArgumentNullException("Plese fill in the blanks completely!");

            User? user = _userRepos.Get(user => user.UserName == username && user.Password == password );

            if (user == null) throw new Exception("We don't have a user like that.");

            Tokens tokens = _tokenRepos.Get(token => token.userID == user.ID);

            return Task.FromResult(tokens);
        }
    }
}
