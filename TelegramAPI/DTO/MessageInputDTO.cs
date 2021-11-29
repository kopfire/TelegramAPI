using System.ComponentModel.DataAnnotations;

namespace testAPI.DTO
{
    /// <summary>
    /// Данные для получения расписания из бд
    /// </summary>
    public class MessageInputDTO
    {
        /// <summary>
        /// Команда
        /// </summary>
        [Required]
        public string Command { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Required]
        public long User { get; set; }
    }
}
