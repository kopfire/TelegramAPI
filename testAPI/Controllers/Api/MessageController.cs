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
using TelegramAPI.Repository;

namespace testAPI.Controllers.Api
{



    /// <summary>
    /// Контроллер для принятия сообщений из бота
    /// </summary>
    [ApiController]
    [Route("api/telegram")]
    public class MessageController : ControllerBase
    {

        private readonly ITimeTableRepository _timeTableService;

        public MessageController(ITimeTableRepository timeTableService)
        {
            _timeTableService = timeTableService;
        }

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        [HttpGet("message")]
        public async Task<IActionResult> AdoptionMessageAsync([FromBody] MessageInputDTO data)
        {
            TimeTables timeTables = await _timeTableService.GetTimeTable(data.User);
            return Ok(timeTables);
        }
    }
}
