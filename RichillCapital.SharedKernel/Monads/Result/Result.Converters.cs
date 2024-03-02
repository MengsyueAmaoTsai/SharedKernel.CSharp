using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class ResultExtensions
{
    /// <summary>
    /// Converts a value to a <see cref="Result{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this TValue value) =>
        Result<TValue>.With(value);

    /// <summary>
    /// Converts a <see cref="Task{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(this Task<TValue> valueTask) =>
        Result<TValue>.With(await valueTask);

    /// <summary>
    /// Converts a <see cref="ValueTask{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TValue>> ToResult<TValue>(this ValueTask<TValue> valueTask) =>
        Result<TValue>.With(await valueTask);

    /// <summary>
    /// Converts an <see cref="Error"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this Error error) =>
        Result<TValue>.Failure(error);

    /// <summary>
    /// Converts an <see cref="Error"/> to a <see cref="Result"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.HasError ?
            Result<TValue>.Failure(errorOr.Errors.First()) :
            Result<TValue>.With(errorOr.Value);

    /// <summary>
    /// Converts a <see cref="Task{ErrorOr{TValue}}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(this Task<ErrorOr<TValue>> errorOrTask)
    {
        var errorOr = await errorOrTask;

        return errorOr.HasError ?
            Result<TValue>.Failure(errorOr.Errors.First()) :
            Result<TValue>.With(errorOr.Value);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(
        this Maybe<TValue> maybe,
        Error error) =>
        maybe.IsNull ?
            Result<TValue>.Failure(error) :
            Result<TValue>.With(maybe.Value);

    /// <summary>
    /// Converts a <see cref="Task{Maybe{TValue}}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
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
    /// <summary>
    /// Converts an <see cref="Error"/> to a <see cref="Result"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result ToResult(this Error error) =>
        Result.Failure(error);
}