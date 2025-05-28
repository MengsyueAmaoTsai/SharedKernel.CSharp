namespace RichillCapital.SharedKernel;

/// <summary>
/// Represents an error in the system.
/// </summary>
public readonly record struct Error
{
    internal const string NullMessage = "Error type cannot be Null.";
    internal const string EmptyCodeMessage = "Error code cannot be null or empty.";

    /// <summary>
    /// Represents a null error.
    /// </summary>
    public static readonly Error Null = new(ErrorType.Null, nameof(ErrorType.Null), string.Empty);

    private Error(ErrorType type, string code, string message) =>
        (Type, Code, Message) = (type, code, message);

    /// <summary>
    /// Gets the type of the error.
    /// </summary>
    public ErrorType Type { get; private init; }

    /// <summary>
    /// Gets the code of the error.
    /// </summary>
    public string Code { get; private init; }

    /// <summary>
    /// Gets the message of the error.
    /// </summary>
    public string Message { get; private init; }

    /// <summary>
    /// Creates a new error with the specified type, code, and message.
    /// </summary>
    /// <param name="type">The type of the error.</param>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created error.</returns>
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

    /// <summary>
    /// Creates a new validation error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created validation error.</returns>
    public static Error Invalid(string code, string message) => Create(ErrorType.Validation, code, message);

    /// <summary>
    /// Creates a new validation error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created validation error.</returns>
    public static Error Invalid(string message) => Create(ErrorType.Validation, nameof(ErrorType.Validation), message);

    /// <summary>
    /// Creates a new unauthorized error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unauthorized error.</returns>
    public static Error Unauthorized(string code, string message) => Create(ErrorType.Unauthorized, code, message);

    /// <summary>
    /// Creates a new unauthorized error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unauthorized error.</returns>
    public static Error Unauthorized(string message) => Create(ErrorType.Unauthorized, nameof(ErrorType.Unauthorized), message);

    /// <summary>
    /// Creates a new access denied error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created access denied error.</returns>
    public static Error AccessDenied(string code, string message) => Create(ErrorType.AccessDenied, code, message);

    /// <summary>
    /// Creates a new access denied error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created access denied error.</returns>
    public static Error AccessDenied(string message) => Create(ErrorType.AccessDenied, nameof(ErrorType.AccessDenied), message);

    /// <summary>
    /// Creates a new not found error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created not found error.</returns>
    public static Error NotFound(string code, string message) => Create(ErrorType.NotFound, code, message);

    /// <summary>
    /// Creates a new not found error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created not found error.</returns>
    public static Error NotFound(string message) => Create(ErrorType.NotFound, nameof(ErrorType.NotFound), message);

    /// <summary>
    /// Creates a new method not allowed error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created method not allowed error.</returns>
    public static Error MethodNotAllowed(string code, string message) => Create(ErrorType.MethodNotAllowed, code, message);

    /// <summary>
    /// Creates a new method not allowed error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created method not allowed error.</returns>
    public static Error MethodNotAllowed(string message) => Create(ErrorType.MethodNotAllowed, nameof(ErrorType.MethodNotAllowed), message);

    /// <summary>
    /// Creates a new conflict error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created conflict error.</returns>
    public static Error Conflict(string code, string message) => Create(ErrorType.Conflict, code, message);

    /// <summary>
    /// Creates a new conflict error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created conflict error.</returns>
    public static Error Conflict(string message) => Create(ErrorType.Conflict, nameof(ErrorType.Conflict), message);

    /// <summary>
    /// Creates a new unsupported media type error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unsupported media type error.</returns>
    public static Error UnsupportedMediaType(string code, string message) => Create(ErrorType.UnsupportedMediaType, code, message);

    /// <summary>
    /// Creates a new unsupported media type error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unsupported media type error.</returns>
    public static Error UnsupportedMediaType(string message) => Create(ErrorType.UnsupportedMediaType, nameof(ErrorType.UnsupportedMediaType), message);

    /// <summary>
    /// Creates a new unexpected error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unexpected error.</returns>
    public static Error Unexpected(string code, string message) => Create(ErrorType.Unexpected, code, message);

    /// <summary>
    /// Creates a new unexpected error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unexpected error.</returns>
    public static Error Unexpected(string message) => Create(ErrorType.Unexpected, nameof(ErrorType.Unexpected), message);

    /// <summary>
    /// Creates a new unavailable error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unavailable error.</returns>
    public static Error Unavailable(string code, string message) => Create(ErrorType.Unavailable, code, message);

    /// <summary>
    /// Creates a new unavailable error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created unavailable error.</returns>
    public static Error Unavailable(string message) => Create(ErrorType.Unavailable, nameof(ErrorType.Unavailable), message);


    /// <summary>
    /// Creates a new timeout error with the specified code and message.
    /// </summary>
    /// <param name="code">The code of the error.</param>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created timeout error.</returns>
    public static Error Timeout(string code, string message) => Create(ErrorType.Timeout, code, message);

    /// <summary>
    /// Creates a new timeout error with the specified message.
    /// </summary>
    /// <param name="message">The message of the error.</param>
    /// <returns>The created timeout error.</returns>
    public static Error Timeout(string message) => Create(ErrorType.Timeout, nameof(ErrorType.Timeout), message);
}

/// <summary>
/// Represents the types of errors that can occur.
/// </summary>
public enum ErrorType
{
    Null = 0,
    Validation = 400,
    Unauthorized = 401,
    AccessDenied = 403,
    NotFound = 404,
    MethodNotAllowed = 405,
    Conflict = 409,
    UnsupportedMediaType = 415,
    Unexpected = 500,
    Unavailable = 503,
    Timeout = 504,
}
