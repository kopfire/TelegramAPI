using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TelegramAPI.Models
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Group { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя в Telegram
        /// </summary>
        [Display(Name = "Id в Telegram")]
        public long TelegramID { get; set; }

    }
}
