using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testAPI.DTO
{
    /// <summary>
    /// Данные расписания
    /// </summary>
    public class TimeTableDTO
    {
        /// <summary>
        /// Идентификатор расписания
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Массив недель
        /// </summary>
        public WeekDTO[] Weeks { get; set; }
    }
}
