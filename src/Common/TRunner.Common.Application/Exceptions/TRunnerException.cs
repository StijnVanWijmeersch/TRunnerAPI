using TRunner.Common.Domain;

namespace TRunner.Common.Application.Exceptions;
public sealed class TRunnerException(string requestName, Error? error = default, Exception? innerException = default) :
    Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;
    public Error? Error { get; } = error;
}
