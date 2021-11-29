using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context); 
            }
            catch (Exception ex)
            {
                var error = new
                {
                    Message = ex.Message,
                    Trace = ex.StackTrace
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"Произошла ошибка: {JsonConvert.SerializeObject(error)}");
            }
        }


    }
}
