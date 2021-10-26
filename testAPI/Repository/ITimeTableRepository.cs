﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Получаем один документ по id студента
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <returns></returns>
        public Task<TimeTables> GetTimeTable(long id);

        /// <summary>
        /// Получаем один документ по группе
        /// </summary>
        /// <param name="id">Название группы</param>
        /// <returns></returns>
        public Task<TimeTables> GetTimeTable(string group);

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="timeTables"></param>
        /// <returns></returns>
        public Task Create(TimeTables timeTables);

        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="timeTables"></param>
        /// <returns></returns>
        public Task Update(TimeTables timeTables); 

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public Task Remove(string id);
    }
}