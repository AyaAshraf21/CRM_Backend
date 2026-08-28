using crm.API.Models;
using crm.Application.Exceptions;

namespace crm.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                await next(context);
            }
            catch(NotFoundException ex)
            {
                var response = new ErrorResponse
                {
                    StatusCode = 404,
                    Message = ex.Message,
                };
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(response);
            }
        }

    }
}
