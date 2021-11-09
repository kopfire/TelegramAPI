using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using testAPI.DTO;
using TelegramAPI.Models;
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
        /// Получение расписания
        /// </summary>
        /// <param name="data">JSON файл с сообщением и id пользователя</param>
        /// <returns>Расписание</returns>
        [HttpGet("message")]
        public async Task<IActionResult> AdoptionMessageAsync([FromBody] MessageInputDTO data)
        {
            Console.WriteLine(data);
            TimeTable timeTables = await _timeTableService.GetTimeTable(data.User);
            return Ok(timeTables);
        }
    }
}
