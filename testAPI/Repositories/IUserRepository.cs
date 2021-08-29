using System.Collections.Generic;
using testAPI.Models;

namespace testAPI.Repositories
{
    /// <summary>
    /// Репозиторий для списка пользователей
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получить список пользователей
        /// </summary>
        public IEnumerable<User> GetUsers();

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="student">Данные пользователя</param>
        /// <returns>Идентификатор пользователя</returns>
        public string AddUser(User user);

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="id">Идентфикатор пользователя</param>
        /// <param name="student">Данные пользователя</param>
        public void UpdateUser(string id, User user);

        /// <summary>
        /// Данные пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public User GetUserById(string id);

        /// <summary>
        /// Данные пользователя по имени пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>Пользователь</returns>
        public User GetByUserName(string userName);
    }
}
