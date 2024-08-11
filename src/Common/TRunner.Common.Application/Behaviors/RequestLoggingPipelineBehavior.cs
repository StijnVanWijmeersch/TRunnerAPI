using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using TRunner.Common.Domain;

namespace TRunner.Common.Application.Behaviors;
internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string moduleName = GetModuleName(typeof(TRequest).FullName!);
        string requestName = typeof(TRequest).Name;

        using (LogContext.PushProperty("Module", moduleName))
        {
            logger.LogInformation("Handling request {RequestName}", requestName);

            TResponse result = await next();

            if (result.IsSuccess)
            {

               logger.LogInformation("Request {RequestName} handled successfully", requestName);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {

                   logger.LogError("Request {RequestName} failed", requestName);
                }
            }

            return result;
        }
    }
    private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}
