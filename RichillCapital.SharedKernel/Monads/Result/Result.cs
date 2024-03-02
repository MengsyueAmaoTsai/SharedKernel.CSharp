namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    private readonly TValue _value;
    private readonly Error _error;

    private Result(Error error)
        : this(false, error, default!)
    {
    }

    private Result(TValue value)
        : this(true, Error.Null, value)
    {
    }

    private Result(bool isSuccess, Error error, TValue value) =>
        (IsSuccess, _error, _value) = (isSuccess, error, value);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error => IsSuccess ? Error.Null : _error;

    public TValue Value => IsFailure ?
        throw new InvalidOperationException("Cannot access the value of a failed result.") :
        _value;

    public TValue ValueOrDefault => IsFailure ? default! : _value;
}

public readonly partial record struct Result
{
    public static readonly Result Success = new(true, Error.Null);

    private Result(Error error)
        : this(false, error)
    {
    }

    private Result(bool isSuccess, Error error) =>
        (IsSuccess, Error) = (isSuccess, error);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }
}