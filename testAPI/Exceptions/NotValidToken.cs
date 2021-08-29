using System;

namespace testAPI.Exceptions
{
    /// <summary>
    /// Не валидный токен
    /// </summary>
    public class NotValidToken : Exception
    {
        /// <summary>
        /// Конструктор класса <see cref="NotValidToken"/>
        /// </summary>
        /// <param name="token">Токен</param>
        public NotValidToken(string token)
           : base($"Not valid token {token}")
        { }
    }
}
