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
using TelegramAPI.DTO;
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
        private readonly GroupsService GroupsDB;

        public MessageController(TimeTablesService context, GroupsService context2)
        {
            TimeTablesDB = context;
            GroupsDB = context2;
        }

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        [HttpPost("message")]
        public async Task<string> AdoptionMessageAsync(string data)
        {
            Console.WriteLine(1);
            Console.WriteLine(data);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var timeTables = await TimeTablesDB.GetTimeTable("ДИТ311");

           
            var jsonString = JsonSerializer.Serialize(timeTables, options);
            return $"{jsonString}";
        }
    }
}
