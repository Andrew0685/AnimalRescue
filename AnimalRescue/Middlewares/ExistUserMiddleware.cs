using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using AnimalRescue.Exceptions;
using AnimalRescue.Exceptions;

namespace AnimalRescue.Middlewares
{
    public class ExistUserMiddleware
    {
        private readonly RequestDelegate _next;
        public ExistUserMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (ExistUserExeption ex)
            {
                await context.Response.WriteAsync($"<br><br><br><br><br><br><br><h1 align=center><font color=#676767>{ex.Message}</font></h1>");
            }
        }
    }
}
