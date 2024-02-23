namespace RichillCapital.SharedKernel;

public readonly record struct Error
{
    public static readonly Error Null = new(ErrorType.Null, string.Empty);

    private Error(ErrorType type, string message) =>
        (Type, Message) = (type, message);

    public ErrorType Type { get; private init; }

    public string Message { get; private init; }

    public static Error Invalid(string message) => new(ErrorType.Validation, message);
    public static Error Unauthorized(string message) => new(ErrorType.Unauthorized, message);
    public static Error Forbidden(string message) => new(ErrorType.Forbidden, message);
    public static Error NotFound(string message) => new(ErrorType.NotFound, message);
    public static Error Conflict(string message) => new(ErrorType.Conflict, message);
    public static Error Unexpected(string message) => new(ErrorType.Unexpected, message);
}