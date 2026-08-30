using crm.API.Models;
using crm.Application.Exceptions;
using FluentValidation;

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
            catch(ValidationException ex)
            {
                var response = new ErrorResponse
                {
                    StatusCode = 400,
                    Message = ex.Message
                };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync (response);
            }
            catch(AlreadyExistsException ex)
            {
                var response = new ErrorResponse
                {
                    StatusCode = 409,
                    Message = ex.Message
                };
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch(BadRequestException ex)
            {
                var response = new ErrorResponse
                {
                    StatusCode = 400,
                    Message = ex.Message
                };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(response);
            }
        }

    }
}
