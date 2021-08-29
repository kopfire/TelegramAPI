using System;

namespace testAPI.Models
{
    /// <summary>
    /// Данные токена
    /// </summary>
    public class UserSecurityTokenDTO
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Контрольная фраза
        /// </summary>
        public string SecretPhrase { get; set; }
    }
}
