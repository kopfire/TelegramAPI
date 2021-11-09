namespace testAPI.DTO
{
    /// <summary>
    /// Данные недели
    /// </summary>
    public class WeekDTO
    {
        /// <summary>
        /// Номер недели
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Массив дней
        /// </summary>
        public DayDTO[] Days { get; set; }
    }
}
