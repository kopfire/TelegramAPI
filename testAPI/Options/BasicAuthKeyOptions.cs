namespace testAPI.Options
{
    /// <summary>
    /// Настройки авторизации
    /// </summary>
    public class BasicAuthKeyOptions
    {
        /// <summary>
        /// Ключ шифрования
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Вектор
        /// </summary>
        public string VectorIV { get; set; } 

    }
}
