using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    /// <summary>
    /// Combines a collection of <see cref="Maybe{TValue}"/> into a single <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Combine(params Maybe<TValue>[] maybes) =>
        maybes.Any(maybe => maybe.IsNull) ?
            Null :
            maybes.Last().Value.ToMaybe();

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2)> Combine<T1, T2>(Maybe<T1> errorOr1, Maybe<T2> errorOr2)
    {
        if (errorOr1.IsNull)
        {
            return Maybe<(T1, T2)>.Null;
        }

        if (errorOr2.IsNull)
        {
            return Maybe<(T1, T2)>.Null;
        }

        return (errorOr1.Value, errorOr2.Value).ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3)> Combine<T1, T2, T3>(Maybe<T1> errorOr1, Maybe<T2> errorOr2, Maybe<T3> errorOr3)
    {
        var errorOrs = Maybe<(T1, T2)>
            .Combine(errorOr1, errorOr2);

        if (errorOrs.IsNull)
        {
            return Maybe<(T1, T2, T3)>.Null;
        }

        if (errorOr3.IsNull)
        {
            return Maybe<(T1, T2, T3)>.Null;
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value).ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(Maybe<T1> errorOr1, Maybe<T2> errorOr2, Maybe<T3> errorOr3, Maybe<T4> errorOr4)
    {
        var errorOrs = Maybe<(T1, T2, T3)>
            .Combine(errorOr1, errorOr2, errorOr3);

        if (errorOrs.IsNull)
        {
            return Maybe<(T1, T2, T3, T4)>.Null;
        }

        if (errorOr4.IsNull)
        {
            return Maybe<(T1, T2, T3, T4)>.Null;
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value).ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(Maybe<T1> errorOr1, Maybe<T2> errorOr2, Maybe<T3> errorOr3, Maybe<T4> errorOr4, Maybe<T5> errorOr5)
    {
        var errorOrs = Maybe<(T1, T2, T3, T4)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4);

        if (errorOrs.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5)>.Null;
        }

        if (errorOr5.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5)>.Null;
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value).ToMaybe();
    }
}