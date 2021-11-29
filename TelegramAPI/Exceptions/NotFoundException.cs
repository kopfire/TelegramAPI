using Newtonsoft.Json;
using System;

namespace testAPI.Exceptions
{
    /// <summary>
    /// Не найдено
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Конструктор класса <see cref="NotFoundException"/>
        /// </summary>
        /// <param name="entityId">Идентификатор сущности</param>
        /// <param name="entityType">тип сущности</param>
        public NotFoundException(object entityId, Type entityType)
           : base($"Absent; {entityType.Name}:{JsonConvert.SerializeObject(entityId)}")
        { }
    }
}
