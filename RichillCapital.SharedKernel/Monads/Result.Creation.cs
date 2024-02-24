using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) => new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Failure(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ?
            Result<TValue>.Success(value) :
            Result<TValue>.Failure(error);

    // Un tests
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TResult> Ensure<TResult>(TResult result, Func<TResult, bool> predicate, Error error) =>
        predicate(result) ?
            Result<TResult>.Success(result) :
            Result<TResult>.Failure(error);
}

public readonly partial record struct Result
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
    public static Result<TValue> Ensure<TValue>(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ?
            Result<TValue>.Success(value) :
            Result<TValue>.Failure(error);
}