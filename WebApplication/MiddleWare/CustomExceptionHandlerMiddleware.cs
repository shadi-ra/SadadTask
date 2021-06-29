using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sadad.Core.Entities.Exceptions;

namespace SadadWebApi.MiddleWare
{
    public class CustomExceptionHandlerMiddleware
    {
        private RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
               

                    case AppExecption e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
