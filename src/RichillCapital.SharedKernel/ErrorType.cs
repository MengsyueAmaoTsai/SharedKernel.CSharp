namespace RichillCapital.SharedKernel;

public enum ErrorType
{
    None = 0,
    Validation = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    MethodNotAllowed = 405,
    Conflict = 409,
    UnsupportedMediaType = 415,
    Unexpected = 500,
    Unavailable = 503,
}
