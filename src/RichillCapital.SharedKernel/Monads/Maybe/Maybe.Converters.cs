using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    /// <summary>
    /// Converts a value to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this TValue value) =>
        Maybe<TValue>.With(value);

    /// <summary>
    /// Converts a <see cref="Task{TValue}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this Task<TValue> valueTask) =>
        Maybe<TValue>.With(await valueTask);

    /// <summary>
    /// Converts a <see cref="ValueTask{TValue}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Maybe<TValue>> ToMaybe<TValue>(this ValueTask<TValue> valueTask) =>
        Maybe<TValue>.With(await valueTask);

    /// <summary>
    /// Converts a <see cref="ErrorOr{TValue}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.HasError ?
            Maybe<TValue>.Null :
            Maybe<TValue>.With(errorOr.Value);

    /// <summary>
    /// Converts a <see cref="Task{ErrorOr{TValue}}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this Task<ErrorOr<TValue>> errorOrTask)
    {
        var errorOr = await errorOrTask;

        return errorOr.HasError ?
            Maybe<TValue>.Null :
            Maybe<TValue>.With(errorOr.Value);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this Result<TValue> result) =>
        result.IsFailure ?
            Maybe<TValue>.Null :
            Maybe<TValue>.With(result.Value);

    /// <summary>
    /// Converts a <see cref="Task{Result{TValue}}"/> to a <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this Task<Result<TValue>> resultTask)
    {
        var result = await resultTask;

        return result.IsFailure ?
            Maybe<TValue>.Null :
            Maybe<TValue>.With(result.Value);
    }
}