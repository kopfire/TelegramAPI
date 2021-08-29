using System.ComponentModel.DataAnnotations;

namespace testAPI.DTO
{
    /// <summary>
    /// Данные для логина
    /// </summary>
    public class LoginInputDTO
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
