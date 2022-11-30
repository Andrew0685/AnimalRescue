using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using AnimalRescue.Exceptions;
using AnimalRescue.Exceptions;

namespace AnimalRescue.Middlewares
{
    public class FileUploadMiddleware
    {
        private readonly RequestDelegate _next;
        public FileUploadMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (FileUploadExeption ex)
            {
                await context.Response.WriteAsync($"<br><br><br><br><br><br><br><h1 align=center><font color=#676767>{ex.Message}</font></h1>");
            }
        }
    }
}
