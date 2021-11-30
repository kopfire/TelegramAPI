using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository
{
    /// <summary>
    /// Сервис для работы с базой данных Specialties
    /// </summary>
    public interface ISpecialtiesRepository
    {

        /// <summary>
        /// Получаем все специальности по id факультета
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Specialties>> GetSpecialties(string id);

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="specialties"></param>
        /// <returns></returns>
        public Task<string> Create(Specialties specialties);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="specialties"></param>
        /// <returns></returns>
        public Task Update(Specialties specialties);

        /// <summary>
        /// Добавление или обновление документа
        /// </summary>
        /// <param name="specialties"></param>
        /// <returns></returns>
        public Task<string> CreateOrUpdate(Specialties specialties);

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}
