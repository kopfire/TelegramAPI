using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Страны
    /// </summary>
    public class Countries
    {
        /// <summary>
        /// Идентификатор страны
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        [Display(Name = "Страна")]
        public string Name { get; set; }
    }
}
