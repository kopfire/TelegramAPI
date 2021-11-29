using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных Universities
    /// </summary>
    public interface IUniversitiesRepository
    {

        /// <summary>
        /// Получаем все университеты в БД
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Universities>> GetUniversities(string id);

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="universities"></param>
        /// <returns></returns>
        public Task Create(Universities universities);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="universities"></param>
        /// <returns></returns>
        public Task Update(Universities universities);

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
