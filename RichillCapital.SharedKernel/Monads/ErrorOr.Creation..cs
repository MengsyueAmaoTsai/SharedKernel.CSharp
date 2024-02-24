using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From(Error[] errors) => new([.. errors]);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From(List<Error> errors) => new(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(TValue value) => new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ? Is(value) : From(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Combine(params ErrorOr<TValue>[] errorOrs)
    {
        var errors = new List<Error>();

        foreach (var errorOr in errorOrs)
        {
            if (errorOr.IsError)
            {
                errors.AddRange(errorOr.Errors);
            }
        }

        return errors.Count == 0 ?
            ErrorOr<TValue>.Is(errorOrs.First().Value) :
            errors.Any(error => error.Type != ErrorType.Validation) ?
                ErrorOr<TValue>.From(errors.First()) :
                ErrorOr<TValue>.From(errors);
    }
}

public static partial class ErrorOr
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From<TValue>(Error[] errors) => ErrorOr<TValue>.From(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From<TValue>(List<Error> errors) => ErrorOr<TValue>.From(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From<TValue>(Error error) => ErrorOr<TValue>.From(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is<TValue>(TValue value) => ErrorOr<TValue>.Is(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure<TValue>(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        ErrorOr<TValue>.Ensure(value, predicate, error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Combine<TValue>(params ErrorOr<TValue>[] errorOrs) =>
        ErrorOr<TValue>.Combine(errorOrs);
}