using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using testAPI.Helpers;
using MongoDB.Bson.Serialization;
using System.Configuration;
using testAPI.DTO;
using TelegramAPI.Models;
using TimeTable = TelegramAPI.Models.TimeTable;

namespace testAPI.Controllers.Api
{



    /// <summary>
    /// Контроллер для принятия сообщений из бота
    /// </summary>
    [ApiController]
    [Route("api/telegram")]
    public class MessageController : ControllerBase
    {

        private readonly TimeTableService db;

        public MessageController(TimeTableService context)
        {
            db = context;
        }

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        [HttpPost("message")]
        public async Task<string> AdoptionMessageAsync(string data)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var timeTables = await db.GetTimeTable();

            TimeTable lol = null;

            foreach (var item in timeTables)
            {
                lol = item;
            }
            var jsonString = JsonSerializer.Serialize(lol, options);
            return $"{jsonString}";
        }
    }
}
