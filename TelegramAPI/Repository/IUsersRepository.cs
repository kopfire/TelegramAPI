using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных Users
    /// </summary>
    public interface IUsersRepository
    {

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Task Create(Users users);

        /// <summary>
        /// Получение документа по TelegramID
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Task<Users> Get(long id);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Task Update(Users users); 

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
