namespace RichillCapital.SharedKernel;

public enum ErrorType
{
    Null = 0,
    Validation = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    Conflict = 409,
    Failure = 500,
}