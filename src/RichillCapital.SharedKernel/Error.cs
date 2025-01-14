namespace RichillCapital.SharedKernel;

public readonly record struct Error
{
    public static readonly Error Null = new(ErrorType.Null, "NullValue", string.Empty);

    private Error(ErrorType type, string code, string message) =>
        (Type, Code, Message) = (type, code, message);

    public ErrorType Type { get; private init; }

    public string Code { get; private init; }

    public string Message { get; private init; }

    public static Error Create(ErrorType type, string code, string message) => new(type, code, message);
    public static Error Invalid(string code, string message) => Create(ErrorType.Validation, code, message);
    public static Error Unauthorized(string code, string message) => Create(ErrorType.Unauthorized, code, message);
    public static Error Forbidden(string code, string message) => Create(ErrorType.Forbidden, code, message);
    public static Error NotFound(string code, string message) => Create(ErrorType.NotFound, code, message);
    public static Error Conflict(string code, string message) => Create(ErrorType.Conflict, code, message);
    public static Error Unexpected(string code, string message) => Create(ErrorType.Unexpected, code, message);
    public static Error Unavailable(string code, string message) => Create(ErrorType.Unavailable, code, message);
    public static Error Invalid(string message) => Create(ErrorType.Validation, nameof(ErrorType.Validation), message);
    public static Error Unauthorized(string message) => Create(ErrorType.Unauthorized, nameof(ErrorType.Unauthorized), message);
    public static Error Forbidden(string message) => Create(ErrorType.Forbidden, nameof(ErrorType.Forbidden), message);
    public static Error NotFound(string message) => Create(ErrorType.NotFound, nameof(ErrorType.NotFound), message);
    public static Error Conflict(string message) => Create(ErrorType.Conflict, nameof(ErrorType.Conflict), message);
    public static Error Unexpected(string message) => Create(ErrorType.Unexpected, nameof(ErrorType.Unexpected), message);
    public static Error Unavailable(string message) => Create(ErrorType.Unavailable, nameof(ErrorType.Unavailable), message);
}