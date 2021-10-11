using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using testAPI.DTO;
using testAPI.Exceptions.Http;
using testAPI.Helpers;
using testAPI.Repositories;

namespace testAPI.Controllers.Api
{



    /// <summary>
    /// Контроллер для принятия сообщений из бота
    /// </summary>
    [ApiController]
    [Route("api/telegram")]
    public class MessageController : ControllerBase
    {

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        [HttpPost("message")]
        public string AdoptionMessageAsync(string data)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var lesson1_1_2 = new Lesson 
            { 
                Number = 2, 
                Name = "Основы информационно-коммуникативной культуры",
                Teacher = "Веклич М.В.",
                Audience = "ДОТ"
            };
            var lesson1_1_4 = new Lesson
            {
                Number = 4,
                Name = "Профессионально-ориентированный иностранный язык",
                Teacher = "Кривых Л.Д.",
                Audience = "ТО.501"
            };
            var lesson1_1_5 = new Lesson
            {
                Number = 5,
                Name = "Профессионально-ориентированный иностранный язык",
                Teacher = "Кривых Л.Д.",
                Audience = "ТО.501"
            };
            var day1_1 = new Day { Name = "Monday", Lessons = new Lesson[] { lesson1_1_2, lesson1_1_4, lesson1_1_5 } };
            var lesson1_2_3 = new Lesson
            {
                Number = 3,
                Name = "Управление данными",
                Teacher = "Лазарев Н.В.",
                Audience = "ДОТ"
            };
            var lesson1_2_5 = new Lesson
            {
                Number = 5,
                Name = "Web - технологии",
                Teacher = "Зорин К.А.",
                Audience = "ТП.614"
            };
            var lesson1_2_6 = new Lesson
            {
                Number = 6,
                Name = "Web - технологии",
                Teacher = "Зорин К.А.",
                Audience = "ТП.614"
            };
            var day1_2 = new Day { Name = "Tuesday", Lessons = new Lesson[] { lesson1_2_3, lesson1_2_5, lesson1_2_6 } };
            var lesson1_4_4 = new Lesson
            {
                Number = 4,
                Name = "Технологии программирования",
                Teacher = "Карпенко А.В.",
                Audience = "ТП.609"
            };
            var lesson1_4_5 = new Lesson
            {
                Number = 5,
                Name = "Элективные курсы по физической культуре и спорту"
            };
            var lesson1_4_6 = new Lesson
            {
                Number = 6,
                Name = "Инструментальные средства информационных систем",
                Teacher = "Евдошенко О.И.",
                Audience = "ТП.604"
            };
            var lesson1_4_7 = new Lesson
            {
                Number = 7,
                Name = "Инструментальные средства информационных систем",
                Teacher = "Евдошенко О.И.",
                Audience = "ТП.604"
            };
            var day1_4 = new Day { Name = "Thursday", Lessons = new Lesson[] { lesson1_4_4, lesson1_4_5, lesson1_4_6, lesson1_4_7 } };
            var lesson1_5_5 = new Lesson
            {
                Number = 5,
                Name = "Основы информационно-коммуникативной культуры",
                Teacher = "Веклич М.В.",
                Audience = "Т.407"
            };
            var lesson1_5_6 = new Lesson
            {
                Number = 6,
                Name = "Моделирование систем",
                Teacher = "Чигирбаева А.А.",
                Audience = "ТП.603"
            };
            var day1_5 = new Day { Name = "Friday", Lessons = new Lesson[] { lesson1_5_5, lesson1_5_6} };
            var lesson1_6_1 = new Lesson
            {
                Number = 1,
                Name = "Управление данными",
                Teacher = "Лазарев Н.В.",
                Audience = "ТП.614"
            };
            var lesson1_6_2 = new Lesson
            {
                Number = 2,
                Name = "Управление данными",
                Teacher = "Лазарев Н.В.",
                Audience = "ТП.614"
            };
            var lesson1_6_3 = new Lesson
            {
                Number = 3,
                Name = "Инфокоммуникационные системы и сети",
                Teacher = "Сахнов Н.В.",
                Audience = "ТП.510"
            };
            var lesson1_6_4 = new Lesson
            {
                Number = 4,
                Name = "Инфокоммуникационные системы и сети",
                Teacher = "Сахнов Н.В.",
                Audience = "ТП.510"
            };
            var day1_6 = new Day { Name = "Saturday", Lessons = new Lesson[] { lesson1_6_1, lesson1_6_2, lesson1_6_3, lesson1_6_4 } };
            var week1 = new Week { Number = 1, Days = new Day[] { day1_1, day1_2, day1_4, day1_5, day1_6 } };
            var lesson2_1_5 = new Lesson
            {
                Number = 7,
                Name = "Web - технологии",
                Teacher = "Морозов Б.Б.",
                Audience = "ДОТ"
            };
            var day2_1 = new Day { Name = "Monday", Lessons = new Lesson[] { lesson2_1_5 } };
            var lesson2_2_3 = new Lesson
            {
                Number = 3,
                Name = "Инструментальные средства информационных систем",
                Teacher = "Евдошенко О.И.",
                Audience = "ДОТ"
            };
            var lesson2_2_5 = new Lesson
            {
                Number = 5,
                Name = "Web - технологии",
                Teacher = "Зорин К.А.",
                Audience = "ТП.614"
            };
            var lesson2_2_6 = new Lesson
            {
                Number = 6,
                Name = "Технологии программирования",
                Teacher = "Карпенко А.В.",
                Audience = "Т.413"
            };
            var day2_2 = new Day { Name = "Tuesday", Lessons = new Lesson[] { lesson2_2_3, lesson2_2_5, lesson2_2_6 } };
            var lesson2_4_5 = new Lesson
            {
                Number = 5,
                Name = "Элективные курсы по физической культуре и спорту"
            };
            var day2_4 = new Day { Name = "Thursday", Lessons = new Lesson[] { lesson2_4_5 } };
            var lesson2_5_2 = new Lesson
            {
                Number = 2,
                Name = "Моделирование систем",
                Teacher = "Ханова А.А.",
                Audience = "ДОТ"
            };
            var lesson2_5_5 = new Lesson
            {
                Number = 5,
                Name = "Основы информационно-коммуникативной культуры",
                Teacher = "Веклич М.В.",
                Audience = "Т.407"
            };
            var lesson2_5_6 = new Lesson
            {
                Number = 6,
                Name = "Моделирование систем",
                Teacher = "Чигирбаева А.А.",
                Audience = "ТП.603"
            };
            var day2_5 = new Day { Name = "Friday", Lessons = new Lesson[] { lesson2_5_2, lesson2_5_5, lesson2_5_6 } };
            var lesson2_6_1 = new Lesson
            {
                Number = 1,
                Name = "Управление данными",
                Teacher = "Лазарев Н.В.",
                Audience = "ТП.614"
            };
            var lesson2_6_2 = new Lesson
            {
                Number = 2,
                Name = "Управление данными",
                Teacher = "Лазарев Н.В.",
                Audience = "ТП.614"
            };
            var lesson2_6_3 = new Lesson
            {
                Number = 3,
                Name = "Инженерный практикум",
                Teacher = "Чигирбаева А.А.",
                Audience = "ТП.604"
            };
            var lesson2_6_4 = new Lesson
            {
                Number = 4,
                Name = "Инженерный практикум",
                Teacher = "Чигирбаева А.А.",
                Audience = "ТП.604"
            };
            var day2_6 = new Day { Name = "Saturday", Lessons = new Lesson[] { lesson2_6_1, lesson2_6_2, lesson2_6_3, lesson2_6_4 } };

            var week2 = new Week { Number = 2, Days = new Day[] { day2_1, day2_2, day2_4, day2_5, day2_6 } };
            var timetable = new TimeTable { Weeks = new Week[] { week1, week2 } };

            var jsonString = JsonSerializer.Serialize(timetable, options);
            Console.WriteLine(jsonString);
            return $"{jsonString}";
        }
    }
}
