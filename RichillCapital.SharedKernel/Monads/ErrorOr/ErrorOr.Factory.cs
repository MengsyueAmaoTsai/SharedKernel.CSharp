using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(TValue value) => new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(List<Error> errors) => new(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(Error[] errors) => new(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            ErrorOr<TValue>.Is(error) :
            ErrorOr<TValue>.Is(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Combine(params ErrorOr<TValue>[] errorOrs) =>
        errorOrs.Any(errorOr => errorOr.IsError) ?
            ErrorOr<TValue>.Is(errorOrs.SelectMany(errorOr => errorOr.ErrorsOrEmpty).Distinct().ToArray()) :
            ErrorOr<TValue>.Is(errorOrs.First().Value);
}