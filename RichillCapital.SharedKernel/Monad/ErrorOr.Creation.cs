using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct ErrorOr<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(TValue value) =>
        new(false, Enumerable.Empty<Error>(), value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From(IEnumerable<Error> errors) =>
        new(true, errors, default!);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From(Error error) =>
        new(true, [error], default!);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure(TValue value, Func<TValue, bool> predicate, Error error) =>
        predicate(value) ?
            ErrorOr<TValue>.Is(value) :
            ErrorOr<TValue>.From(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure(params ErrorOr<TValue>[] errorOrs) =>
        errorOrs.Any(x => x.IsError) ?
            ErrorOr<TValue>.From(errorOrs
                .SelectMany(errorOr => errorOr.Errors)) :
            ErrorOr<TValue>.Is(errorOrs.First().Value);
}

public readonly partial record struct ErrorOr
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is<TValue>(TValue value) =>
       ErrorOr<TValue>.Is(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From<TValue>(IEnumerable<Error> errors) =>
        ErrorOr<TValue>.From(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> From<TValue>(Error error) =>
        ErrorOr<TValue>.From(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure<TValue>(TValue value, Func<TValue, bool> predicate, Error error) =>
        ErrorOr<TValue>.Ensure(value, predicate, error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure<TValue>(params ErrorOr<TValue>[] errorOrs) =>
        ErrorOr<TValue>.Ensure(errorOrs);
}