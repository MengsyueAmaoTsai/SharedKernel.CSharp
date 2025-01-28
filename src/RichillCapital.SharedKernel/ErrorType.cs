namespace RichillCapital.SharedKernel;

public enum ErrorType
{
    Null = 0,
    Validation = 400,
    Unauthorized = 401,
    Forbidden = 403,
    MethodNotAllowed = 405,
    UnsupportedMediaType = 415,
    NotFound = 404,
    Conflict = 409,
    Unexpected = 500,
    Unavailable = 503,
}
