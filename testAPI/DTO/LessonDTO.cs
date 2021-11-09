namespace testAPI.DTO
{
    /// <summary>
    /// Данные пар
    /// </summary>
    public class LessonDTO
    {
        /// <summary>
        /// Номер пары
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Название пары
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ФИО преподавателя
        /// </summary>
        public string Teacher { get; set; }

        /// <summary>
        /// Аудитория
        /// </summary>
        public string Audience { get; set; }
    }
}
