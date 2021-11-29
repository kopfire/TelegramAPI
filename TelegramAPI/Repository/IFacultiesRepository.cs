using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных Faculties
    /// </summary>
    public interface IFacultiesRepository
    {

        /// <summary>
        /// Получаем все факультеты по id университета
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Faculties>> GetFaculties(string id);

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="faculties"></param>
        /// <returns></returns>
        public Task<string> Create(Faculties faculties);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="faculties"></param>
        /// <returns></returns>
        public Task Update(Faculties faculties);

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
