using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using testAPI.DTO;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Расписания
    /// </summary>
    public class TimeTable
    {
        /// <summary>
        /// Идентификатор расписания
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Speciality { get; set; }
        
        /// <summary>
        /// Название группы
        /// </summary>
        [Display(Name = "Группа")]
        public string Group { get; set; }

        /// <summary>
        /// Массив четной и нечетной недели
        /// </summary>
        [Display(Name = "Недели")]
        public List<WeekDTO> Weeks { get; set; }
    }
}
