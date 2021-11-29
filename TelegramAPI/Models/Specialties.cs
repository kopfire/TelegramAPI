using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Специальности
    /// </summary>
    public class Specialties
    {
        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор факультета, к которому принадлежит специальность
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Facylty { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [Display(Name = "Специальность")]
        public string Name { get; set; }
    }
}
