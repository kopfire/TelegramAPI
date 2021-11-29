using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных Cities
    /// </summary>
    public interface ICitiesRepository
    {

        /// <summary>
        /// Получаем все города по id страны
        /// /// </summary>
        /// <param name="id">Идентификатор страны</param>
        /// <returns></returns>
        public Task<IEnumerable<Cities>> GetCities(string id);

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public Task Create(Cities cities);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public Task Update(Cities cities); 

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
