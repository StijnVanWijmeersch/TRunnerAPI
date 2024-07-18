namespace TRunner.Domain.Abstractions;
public record Error
{
    public string Code { get; set; }
    public string Message { get; set; }
    public ErrorType Type { get; set; }

    public Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public static readonly Error None = new (string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new (
        "General.NullValue",
        "Null value was provided",
        ErrorType.Failure);

    public static Error Failure(string code, string message) =>
        new (code, message, ErrorType.Failure);

    public static Error NotFound(string code, string message) =>
        new (code, message, ErrorType.NotFound);

    public static Error Problem(string code, string message) =>
        new (code, message, ErrorType.Problem);

    public static Error Conflict(string code, string message) =>
        new (code, message, ErrorType.Conflict);
}
