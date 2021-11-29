using System.Collections.Generic;

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
        public List<DayDTO> Days { get; set; }
    }
}
