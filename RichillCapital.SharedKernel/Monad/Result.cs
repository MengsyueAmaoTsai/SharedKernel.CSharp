namespace RichillCapital.SharedKernel.Monad;

public record class Result<TValue> : Result
{
    private readonly TValue? _value;

    private Result(bool isSuccess, Error error, TValue value)
        : base(isSuccess, error) => _value = value;

    public TValue Value => IsFailure ?
        throw new InvalidOperationException("Cannot access value for a failure result.") :
        _value!;

    public static Result<TValue> Success(TValue value) =>
        new(true, Error.Null, value);

    public static implicit operator Result<TValue>(TValue value) => Success(value);

    public static new Result<TValue> Failure(Error error) =>
        new(false, error, default!);

    public static implicit operator Result<TValue>(Error error) => Failure(error);

    public Result<TDestination> Map<TDestination>(Func<TValue, TDestination> map) =>
         IsSuccess ?
            Result<TDestination>.Success(map(Value)) :
            Result<TDestination>.Failure(Error);
}

public record class Result
{
    internal protected Result(bool isSuccess, Error error) =>
        (IsSuccess, Error) = (isSuccess, error);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    public static Result Success() => new(true, Error.Null);

    public static Result Failure(Error error) => new(false, error);

    public static implicit operator Result(Error error) => Failure(error);

    public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.Success(value);
}