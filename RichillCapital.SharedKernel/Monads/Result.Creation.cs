using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public sealed partial record class Result<TValue> : Result
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) => new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static new Result<TValue> Failure(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ? Success(value) : Failure(error);
}

public partial record class Result
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Success() => new(true, Error.Null);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Failure(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success<TValue>(TValue value) =>
        Result<TValue>.Success(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Failure<TValue>(Error error) =>
        Result<TValue>.Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Ensure<TValue>(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ?
            Success() :
            Failure(error);
}