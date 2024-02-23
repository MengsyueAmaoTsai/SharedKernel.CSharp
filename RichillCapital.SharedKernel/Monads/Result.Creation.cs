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
}