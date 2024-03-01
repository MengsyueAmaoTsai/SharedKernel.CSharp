using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class ResultExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this TValue value)
    {
        return Result<TValue>.With(value);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(this Task<TValue> valueTask)
    {
        var value = await valueTask;
        return Result<TValue>.With(value);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this Error error)
    {
        return Result<TValue>.Failure(error);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result ToResult(this Error error)
    {
        return Result.Failure(error);
    }
}