using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct Maybe<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> With(TValue? value) => new(true, value!);
}

public readonly partial record struct Maybe
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> With<TValue>(TValue value) =>
    Maybe<TValue>.With(value);
}