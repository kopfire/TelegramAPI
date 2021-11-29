using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных Cities
    /// </summary>
    public interface ICountriesRepository
    {

        /// <summary>
        /// Получаем все страны в БД
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Countries>> GetCounties();

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public Task Create(Countries countries);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public Task Update(Countries countries);

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
