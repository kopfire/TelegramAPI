using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Города
    /// </summary>
    public class Cities
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор страны, к которой принадлежит город
        /// </summary>
        [Display(Name = "Страна")]
        public string Country { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [Display(Name = "Город")]
        public string Name { get; set; }
    }
}
