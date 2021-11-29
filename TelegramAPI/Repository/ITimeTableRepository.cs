using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных TimeTables
    /// </summary>
    public interface ITimeTableRepository
    {
        /// <summary>
        /// Получаем один документ по id 
        /// /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task<TimeTable> GetTimeTable(string id);

        /// <summary>
        /// Получаем один документ по группе
        /// </summary>
        /// <param name="group">Название группы</param>
        /// <returns></returns>
        public Task<TimeTable> GetTimeTableByGroup(string group);

        /// <summary>
        /// Получаем все раписания по id специальности
        /// </summary>
        /// <param name="id">Идентификатор специальности</param>
        /// <returns></returns>
        public Task<IEnumerable<TimeTable>> GetTimeTables(string id);

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="timeTables"></param>
        /// <returns></returns>
        public Task Create(TimeTable timeTables);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="timeTables"></param>
        /// <returns></returns>
        public Task Update(TimeTable timeTables); 

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
