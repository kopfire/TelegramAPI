﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Exceptions.Http
{
    /// <summary>
    /// Ошибка авторизации (код 401)
    /// </summary>
    public class UnauthorizedException : HttpException
    {
        /// <summary>
        /// Создание экземпляра класса <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="errorObject">Объект описания ошибки</param>
        public UnauthorizedException(object errorObject)
            : base(StatusCodes.Status401Unauthorized, errorObject)
        { }

        /// <summary>
        /// Создание экземпляра класса <see cref="UnauthorizedException"/>
        /// </summary>
        public UnauthorizedException()
            : this(null)
        { }
    }
}
