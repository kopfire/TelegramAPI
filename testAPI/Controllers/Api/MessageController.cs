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
using TimeTable = TelegramAPI.Models.TimeTables;
using System.Net.Http;

namespace testAPI.Controllers.Api
{



    /// <summary>
    /// Контроллер для принятия сообщений из бота
    /// </summary>
    [ApiController]
    [Route("api/telegram")]
    public class MessageController : ControllerBase
    {

        private readonly TimeTablesService TimeTablesDB;

        public MessageController(TimeTablesService context)
        {
            TimeTablesDB = context;
        }

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        [HttpPost("message")]
        public async Task<string> AdoptionMessageAsync([FromBody] MessageInputDTO data)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            TimeTables timeTables = await TimeTablesDB.GetTimeTable(data.User);

            var jsonString = JsonSerializer.Serialize(timeTables, options);
            Console.WriteLine(jsonString);
            Console.WriteLine(data.User);
            Console.WriteLine(data.Command);
            return $"{jsonString}";
        }
    }
}
