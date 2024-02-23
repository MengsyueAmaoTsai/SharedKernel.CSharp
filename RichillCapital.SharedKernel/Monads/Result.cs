namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    private readonly TValue _value;

    private Result(Error error)
        : this(false, error, default!)
    {
    }

    private Result(TValue value)
        : this(true, Error.Null, value)
    {
    }

    private Result(bool isSuccess, Error error, TValue value) =>
        (IsSuccess, Error, _value) = (isSuccess, error, value);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    public TValue Value => IsFailure ?
        throw new InvalidOperationException("Cannot access the value of a failed result.") :
        _value;

    public TValue ValueOrDefault => IsFailure ? default! : _value;

    public static implicit operator Result<TValue>(TValue value) =>
        Success(value);

    public static implicit operator Result<TValue>(Error error) =>
        Failure(error);
}