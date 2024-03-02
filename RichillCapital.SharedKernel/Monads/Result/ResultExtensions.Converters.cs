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
    public static async ValueTask<Result<TValue>> ToResult<TValue>(this ValueTask<TValue> valueTask)
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
    public static Result<TValue> ToResult<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.HasError ?
            Result<TValue>.Failure(errorOr.Errors.First()) :
            Result<TValue>.With(errorOr.Value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(this Task<ErrorOr<TValue>> errorOrTask)
    {
        var errorOr = await errorOrTask;

        return errorOr.HasError ?
            Result<TValue>.Failure(errorOr.Errors.First()) :
            Result<TValue>.With(errorOr.Value);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(
        this Maybe<TValue> maybe,
        Error error) =>
        maybe.IsNull ?
            Result<TValue>.Failure(error) :
            Result<TValue>.With(maybe.Value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(
        this Task<Maybe<TValue>> maybeTask,
        Error error)
    {
        var maybe = await maybeTask;

        return maybe.IsNull ?
            Result<TValue>.Failure(error) :
            Result<TValue>.With(maybe.Value);
    }
}

public static partial class ResultExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result ToResult(this Error error)
    {
        return Result.Failure(error);
    }
}