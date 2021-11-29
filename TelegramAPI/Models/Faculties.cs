using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Факультеты
    /// </summary>
    public class Faculties
    {
        /// <summary>
        /// Идентификатор факультета
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор университета, к которой принадлежит факультет
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string University { get; set; }

        /// <summary>
        /// Название факультета
        /// </summary>
        [Display(Name = "Факультет")]
        public string Name { get; set; }
    }
}
