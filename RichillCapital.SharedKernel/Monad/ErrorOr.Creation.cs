using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monad;

public sealed partial record class ErrorOr<TValue>
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
}

public partial record class ErrorOr
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
}