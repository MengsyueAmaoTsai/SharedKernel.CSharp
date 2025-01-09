using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class ErrorOrExtensions
{
    /// <summary>
    /// Converts a value to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this TValue value) =>
        ErrorOr<TValue>.With(value);

    /// <summary>
    /// Converts a <see cref="Task{TValue}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this Task<TValue> valueTask) =>
        ErrorOr<TValue>.With(await valueTask);

    /// <summary>
    /// Converts a <see cref="ValueTask{TValue}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<ErrorOr<TValue>> ToErrorOr<TValue>(this ValueTask<TValue> valueTask) =>
        ErrorOr<TValue>.With(await valueTask);

    /// <summary>
    /// Converts an <see cref="Error"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error error) =>
        ErrorOr<TValue>.WithError(error);

    /// <summary>
    /// Converts a <see cref="List{Error}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this List<Error> errors) =>
        ErrorOr<TValue>.WithError(errors);

    /// <summary>
    /// Converts an <see cref="Error[]"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error[] errors) =>
        ErrorOr<TValue>.WithError(errors);

    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this Result<TValue> result) =>
        result.IsFailure ?
            ErrorOr<TValue>.WithError(result.Error) :
            ErrorOr<TValue>.With(result.Value);

    /// <summary>
    /// Converts a <see cref="Task{Result{TValue}}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this Task<Result<TValue>> resultTask)
    {
        var result = await resultTask;

        return result.IsFailure ?
            ErrorOr<TValue>.WithError(result.Error) :
            ErrorOr<TValue>.With(result.Value);
    }

    /// <summary>
    /// Converts a <see cref="ValueTask{Result{TValue}}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(
        this Maybe<TValue> maybe,
        Error error) =>
        maybe.IsNull ?
            ErrorOr<TValue>.WithError(error) :
            ErrorOr<TValue>.With(maybe.Value);

    /// <summary>
    /// Converts a <see cref="Task{Maybe{TValue}}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(
        this Task<Maybe<TValue>> maybeTask,
        Error error)
    {
        var maybe = await maybeTask;

        return maybe.IsNull ?
            ErrorOr<TValue>.WithError(error) :
            ErrorOr<TValue>.With(maybe.Value);
    }
}