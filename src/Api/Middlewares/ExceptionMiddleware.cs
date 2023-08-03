using Application.Common.Exceptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Middlewares
{
    public class ExceptionMiddleware : IExceptionFilter
    {
        private readonly IHostEnvironment _env;
        private readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ExceptionMiddleware(IHostEnvironment env)
        {
            _env = env;
            _exceptionHandlers = new()
            {
                { typeof(EntityValidationException), EntityValidationHandler },
                { typeof(NotFoundException), NotFoundHandler },
                { typeof(ValidationException), ValidationHandler }
            };
        }

        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;

            Type type = context.Exception.GetType();

            if (_exceptionHandlers.TryGetValue(type, out Action<ExceptionContext> value))
            {
                value.Invoke(context);
                return;
            }

            DefaultExceptionHandler(context);
        }

        private void DefaultExceptionHandler(ExceptionContext context)
        {
            Exception exception = context.Exception;

            var details = new ProblemDetails
            {
                Title = "An unexpected error ocurred",
                Status = StatusCodes.Status422UnprocessableEntity,
                Type = "UnexpectedError",
                Detail = exception.Message
            };

            if (_env.IsDevelopment())
                details.Extensions.Add("StackTrace", exception.StackTrace);

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void NotFoundHandler(ExceptionContext context)
        {
            var exception = (NotFoundException)context.Exception;

            var details = new ProblemDetails()
            {
                Title = "The specified resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void EntityValidationHandler(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Title = "One or more validation errors ocurred",
                Status = StatusCodes.Status422UnprocessableEntity,
                Type = "UnprocessableEntity",
                Detail = context.Exception!.Message
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void ValidationHandler(ExceptionContext context)
        {
            var exception = (ValidationException)context.Exception;

            var details = new ValidationProblemDetails(exception.Errors);

            context.Result = new BadRequestObjectResult(details)
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
            
            context.ExceptionHandled = true;
        }
    }
}
