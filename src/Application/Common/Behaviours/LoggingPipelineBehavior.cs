using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : notnull
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, 
                                            RequestHandlerDelegate<TResponse> next, 
                                            CancellationToken cancellationToken)
        {
            var requestId = Guid.NewGuid().ToString();

            _logger.LogInformation("Starting request {@RequestId} - {@RequestName}, {@DateTimeUtc}", 
                                   requestId, 
                                   typeof(TRequest).Name, 
                                   DateTime.UtcNow);

            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError("Request failure {@RequestId} - {@RequestName}, {@Error} {@DateTimeUtc}", 
                                 requestId, 
                                 typeof(TRequest).Name, 
                                 ex.Message + ex?.StackTrace + ex?.InnerException?.Message, 
                                 DateTime.UtcNow);
                throw;
            }
            finally
            {
                _logger.LogInformation("Completed request {@RequestId} - {@RequestName}, {@DateTimeUtc}",
                                       requestId,
                                       typeof(TRequest).Name,
                                       DateTime.UtcNow);
            }
        }
    }
}
