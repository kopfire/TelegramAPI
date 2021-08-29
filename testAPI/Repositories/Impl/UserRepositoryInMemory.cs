using System.Collections.Generic;
using System.Linq;
using testAPI.Exceptions;
using testAPI.Models;

namespace testAPI.Repositories.Impl
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public class UserRepositoryInMemory : IUserRepository
    {
        private List<User> _users;

        /// <summary>
        /// Конструктор класса <see cref="UserRepositoryInMemory"/>
        /// </summary>
        public UserRepositoryInMemory()
        {
            var admin = new User { UserName = "Admin" };
            admin.SetPassword(admin.UserName);

            _users = new List<User>
            {
                admin
            };
        }

        ///<inheritdoc/>
        public string AddUser(User user)
        {
            _users.Add(user);

            return user.Id;
        }

        ///<inheritdoc/>
        public User GetUserById(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException(id, typeof(User));
        }

        ///<inheritdoc/>
        public IEnumerable<User> GetUsers() => _users;

        ///<inheritdoc/>
        public void UpdateUser(string id, User data)
        {
            var user = _users.FirstOrDefault(x => x.Id == id)
                ?? throw new NotFoundException(id, typeof(Student));

            user.UserName = data.UserName;
            user.GenerationToken();
        }

        ///<inheritdoc/>
        public User GetByUserName(string userName)
        { 
            return _users.FirstOrDefault(x => x.UserName.ToUpper() == userName.ToUpper()) ?? throw new NotFoundException(userName, typeof(User));
        }
    }
}
