using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure) =>
        !ensure(value) ?
            Null :
            value.ToMaybe();
}

public static partial class MaybeExtensions
{
    public static Maybe<TValue> Ensure<TValue>(
        this Maybe<TValue> maybe,
        Func<TValue, bool> ensure) =>
        maybe.IsNull ?
            Maybe<TValue>.Null :
            !ensure(maybe.Value) ?
                Maybe<TValue>.Null :
                maybe.Value.ToMaybe();
}