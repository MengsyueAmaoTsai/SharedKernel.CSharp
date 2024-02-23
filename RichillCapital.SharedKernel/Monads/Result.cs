namespace RichillCapital.SharedKernel.Monads;

public sealed partial record class Result<TValue> : Result
{
    private readonly TValue _value;

    private Result(Error error)
        : base(error) =>
        _value = default!;

    private Result(TValue value)
        : base(true, Error.Null) =>
        _value = value;

    public TValue Value => IsFailure ?
        throw new InvalidOperationException("Cannot access the value of a failed result.") :
        _value;

    public TValue ValueOrDefault => IsFailure ? default! : _value;

    public static implicit operator Result<TValue>(TValue value) =>
        Success(value);

    public static implicit operator Result<TValue>(Error error) =>
        Failure(error);
}

public partial record class Result
{
    private Result(Error error)
        : this(false, error)
    {
    }

    internal protected Result(bool isSuccess, Error error) =>
        (IsSuccess, Error) = (isSuccess, error);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    public static implicit operator Result(Error error) =>
        Failure(error);
}