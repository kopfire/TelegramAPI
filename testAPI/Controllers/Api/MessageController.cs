using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        private readonly IUsersRepository _usersService;

        public MessageController(ITimeTableRepository timeTableService, IUsersRepository usersService)
        {
            _timeTableService = timeTableService;
            _usersService = usersService;
        }

        /// <summary>
        /// Получение расписания
        /// </summary>
        /// <param name="UserID">Идентификатор пользователя</param>
        /// <returns>Расписание</returns>
        [HttpGet("message")]
        public async Task<IActionResult> AdoptionMessageAsync(long UserID)
        {
            TimeTable timeTables = await _timeTableService.GetTimeTable(_usersService.GetTimeTable(UserID).Result);
            return Ok(timeTables);
        }
    }
}
