using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using testAPI.Repositories;

namespace testAPI.Attributes
{
    /// <summary>
    /// Фильт для авторизации по токену
    /// </summary>
    public class BasicAuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Конструктор класса <see cref="BasicAuthFilter"/>
        /// </summary>
        public BasicAuthFilter(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("CustomAuth"))
            {
                var token = context.HttpContext.Request.Headers["CustomAuth"].ToString().Split('.');

                try
                {
                    var user = _userRepository.GetUserById(token[1]);

                    if (token[0] == user.AccessToken)
                        return;
                }
                catch
                {
                    context.Result = new UnauthorizedResult();
                }

                context.Result = new UnauthorizedResult();
                return;
            }

            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
