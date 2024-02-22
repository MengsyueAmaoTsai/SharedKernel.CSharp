using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monad;

public partial record class Result<TValue> : Result
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) =>
        new(true, Error.Null, value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static new Result<TValue> Failure(Error error) =>
        new(false, error, default!);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ?
            Result<TValue>.Success(value) :
            Result<TValue>.Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(Maybe<TValue> maybe, Error error) =>
        maybe.HasValue ?
            Result<TValue>.Success(maybe.Value) :
            Result<TValue>.Failure(error);
}

public partial record class Result
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Success() => new(true, Error.Null);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Failure(Error error) => new(false, error);

    public static implicit operator Result(Error error) =>
        Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success<TValue>(TValue value) =>
        Result<TValue>.Success(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure<TValue>(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        Result<TValue>.Ensure(value, predicate, error);
}