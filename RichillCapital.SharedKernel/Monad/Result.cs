using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monad;

public partial record class Result<TValue> : Result
{
    private readonly TValue? _value;

    private Result(bool isSuccess, Error error, TValue value)
        : base(isSuccess, error) => _value = value;

    public TValue Value => IsFailure ?
        throw new InvalidOperationException("Cannot access value for a failure result.") :
        _value!;

    public static implicit operator Result<TValue>(TValue value) =>
        Result<TValue>.Success(value);

    public static implicit operator Result<TValue>(Error error) =>
        Result<TValue>.Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Result<TValue> Ensure(Func<TValue, bool> predicate, Error error) =>
        Result<TValue>.Ensure(Value, predicate, error);
}

public partial record class Result
{
    internal protected Result(bool isSuccess, Error error) =>
        (IsSuccess, Error) = (isSuccess, error);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }
}