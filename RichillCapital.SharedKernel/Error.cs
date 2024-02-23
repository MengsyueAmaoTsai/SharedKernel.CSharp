namespace RichillCapital.SharedKernel;

public readonly record struct Error : IError
{
    public static readonly Error Null = new(ErrorType.Null, string.Empty);

    private Error(ErrorType type, string message) =>
        (Type, Message) = (type, message);

    public ErrorType Type { get; private init; }

    public string Message { get; private init; }

    public static IError Invalid(string message) => new Error(ErrorType.Validation, message);
    public static IError Unauthorized(string message) => new Error(ErrorType.Unauthorized, message);
    public static IError Forbidden(string message) => new Error(ErrorType.Forbidden, message);
    public static IError NotFound(string message) => new Error(ErrorType.NotFound, message);
    public static IError Conflict(string message) => new Error(ErrorType.Conflict, message);
    public static IError Unexpected(string message) => new Error(ErrorType.Unexpected, message);
    public static IError Unavailable(string message) => new Error(ErrorType.Unavailable, message);
}