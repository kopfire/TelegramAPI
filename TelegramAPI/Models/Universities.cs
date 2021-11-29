using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Университеты
    /// </summary>
    public class Universities
    {
        /// <summary>
        /// Идентификатор университета
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор города, к которому принадлежит университет
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string City { get; set; }

        /// <summary>
        /// Название университета
        /// </summary>
        [Display(Name = "Университет")]
        public string Name { get; set; }
    }
}
