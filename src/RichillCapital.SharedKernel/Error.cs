namespace RichillCapital.SharedKernel;

public readonly record struct Error
{
    internal const string NullMessage = "Error type cannot be Null.";
    internal const string EmptyCodeMessage = "Error code cannot be null or empty.";

    public static readonly Error Null = new(ErrorType.Null, nameof(ErrorType.Null), string.Empty);

    private Error(ErrorType type, string code, string message) =>
        (Type, Code, Message) = (type, code, message);

    public ErrorType Type { get; private init; }
    public string Code { get; private init; }
    public string Message { get; private init; }

    public static Error Create(
        ErrorType type,
        string code,
        string message)
    {
        if (type == ErrorType.Null)
        {
            throw new ArgumentException(NullMessage);
        }

        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentException(EmptyCodeMessage);
        }

        return new(type, code, message);
    }

    public static Error Invalid(string code, string message) => Create(ErrorType.Validation, code, message);
    public static Error Invalid(string message) => Create(ErrorType.Validation, nameof(ErrorType.Validation), message);

    public static Error Unauthorized(string code, string message) => Create(ErrorType.Unauthorized, code, message);
    public static Error Unauthorized(string message) => Create(ErrorType.Unauthorized, nameof(ErrorType.Unauthorized), message);

    public static Error AccessDenied(string code, string message) => Create(ErrorType.AccessDenied, code, message);
    public static Error AccessDenied(string message) => Create(ErrorType.AccessDenied, nameof(ErrorType.AccessDenied), message);

    public static Error NotFound(string code, string message) => Create(ErrorType.NotFound, code, message);
    public static Error NotFound(string message) => Create(ErrorType.NotFound, nameof(ErrorType.NotFound), message);

    public static Error MethodNotAllowed(string code, string message) => Create(ErrorType.MethodNotAllowed, code, message);
    public static Error MethodNotAllowed(string message) => Create(ErrorType.MethodNotAllowed, nameof(ErrorType.MethodNotAllowed), message);

    public static Error Conflict(string code, string message) => Create(ErrorType.Conflict, code, message);
    public static Error Conflict(string message) => Create(ErrorType.Conflict, nameof(ErrorType.Conflict), message);

    public static Error UnsupportedMediaType(string code, string message) => Create(ErrorType.UnsupportedMediaType, code, message);
    public static Error UnsupportedMediaType(string message) => Create(ErrorType.UnsupportedMediaType, nameof(ErrorType.UnsupportedMediaType), message);

    public static Error Unexpected(string code, string message) => Create(ErrorType.Unexpected, code, message);
    public static Error Unexpected(string message) => Create(ErrorType.Unexpected, nameof(ErrorType.Unexpected), message);

    public static Error Unavailable(string code, string message) => Create(ErrorType.Unavailable, code, message);
    public static Error Unavailable(string message) => Create(ErrorType.Unavailable, nameof(ErrorType.Unavailable), message);
}
