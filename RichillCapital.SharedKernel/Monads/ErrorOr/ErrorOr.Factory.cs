using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> With(TValue value)
    {
        return new(value);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> WithError(Error error)
    {
        return new(error);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> WithError(List<Error> errors)
    {
        return new(errors);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> WithError(Error[] errors)
    {
        return new(errors);
    }
}