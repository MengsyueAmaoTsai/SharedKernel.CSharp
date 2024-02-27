using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Have(TValue value) =>
        value is null ?
            Null :
            new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure) =>
        !ensure(value) ?
            Null :
            Maybe<TValue>.Have(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Combine(params Maybe<TValue>[] maybes) =>
        maybes.Any(maybe => maybe.HasNoValue) ?
            Null :
            Maybe<TValue>.Have(maybes[0].Value);
}