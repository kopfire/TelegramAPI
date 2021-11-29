using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Exceptions.Http;

namespace testAPI.Attributes
{
    /// <summary>
    /// Обработка исключений
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <inheritdoc/>
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception is HttpException httpException)
            {
                context.HttpContext.Response.StatusCode = httpException.StatusCode;
                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = httpException.Message;

                context.ExceptionHandled = true;
                return;
            }

            base.OnException(context);
        }
    }
}
