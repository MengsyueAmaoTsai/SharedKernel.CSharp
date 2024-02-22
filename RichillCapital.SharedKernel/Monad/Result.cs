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

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) =>
        new(true, Error.Null, value);

    public static implicit operator Result<TValue>(TValue value) => Success(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static new Result<TValue> Failure(Error error) =>
        new(false, error, default!);

    public static implicit operator Result<TValue>(Error error) => Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ?
            Success(value) :
            Failure(error);
}

public partial record class Result
{
    internal protected Result(bool isSuccess, Error error) =>
        (IsSuccess, Error) = (isSuccess, error);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Success() => new(true, Error.Null);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Failure(Error error) => new(false, error);

    public static implicit operator Result(Error error) => Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.Success(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure<TValue>(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        Result<TValue>.Ensure(value, predicate, error);
}