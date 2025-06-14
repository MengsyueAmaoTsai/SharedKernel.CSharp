namespace RichillCapital.SharedKernel;

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
