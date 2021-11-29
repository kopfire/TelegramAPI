namespace testAPI.DTO
{
    /// <summary>
    /// Данные дня
    /// </summary>
    public class DayDTO
    {
        /// <summary>
        /// Номер дня
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Массив пар
        /// </summary>
        public LessonDTO[] Lessons { get; set; }
    }
}
