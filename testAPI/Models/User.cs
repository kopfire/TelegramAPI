using System;
using System.Security.Cryptography;
using System.Text;
using testAPI.Helpers;

namespace testAPI.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Конструктор класса <see cref="User"/>
        /// </summary>
        public User( )
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Имя пользвателя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string HashPassword { get; private set; }

        /// <summary>
        /// Соль
        /// </summary>
        public string Salt { get; private set; }

        /// <summary>
        /// Токен доступа
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Генерация токена доступа
        /// </summary>
        public string GenerationToken()
        {
            AccessToken = Guid.NewGuid().ToString();

            return AccessToken;
        }

        public void SetPassword(string password)
        {
            Salt = Guid.NewGuid().ToString();

            HashPassword = PasswordHasherHelper.HashString($"{password}{Salt}");
        }

    }
}
