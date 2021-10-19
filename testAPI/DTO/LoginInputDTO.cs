﻿using System.ComponentModel.DataAnnotations;

namespace testAPI.DTO
{
    /// <summary>
    /// Данные для логина
    /// </summary>
    public class dfh
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Command { get; set; }


        [Required]
        public long User { get; set; }
    }
}
