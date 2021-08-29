using Microsoft.AspNetCore.Mvc;
using System;
using testAPI.DTO;
using testAPI.Exceptions.Http;
using testAPI.Helpers;
using testAPI.Repositories;

namespace testAPI.Controllers.Api
{
    /// <summary>
    /// Контроллер для пользователей
    /// </summary>
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Конструктор класса <see cref="UserController"/>
        /// </summary>
        /// <param name="userRepository">Репозиторий</param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        [HttpPost("login")]
        public string GenerateToken([FromBody]LoginInputDTO data)
        {
            var user = _userRepository.GetByUserName(data.UserName);

            var hash = PasswordHasherHelper.HashString($"{data.Password}{user.Salt}");

            if (hash != user.HashPassword)
                throw new UnauthorizedException(user);

            return $"{user.GenerationToken()}.{user.Id}";
        }
    }
}
