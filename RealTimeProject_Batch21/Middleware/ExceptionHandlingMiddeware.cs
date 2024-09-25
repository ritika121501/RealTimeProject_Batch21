using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;

namespace RealTimeProject_Batch21.Middleware
{
    public class ExceptionHandlingMiddeware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddeware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //it is used for calling another middleware in the pipeline, once the
                //execution of this middleware is complete
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                Console.WriteLine(ex.ToString());
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception) { 
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            var result = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "This is custome middleware",
                Detailed = exception.Message
            };

            return context.Response.WriteAsJsonAsync(result);

        }
    }
}
