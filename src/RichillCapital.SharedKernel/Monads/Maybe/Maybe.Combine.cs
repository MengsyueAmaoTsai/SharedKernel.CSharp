using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Combine(params Maybe<TValue>[] maybes) =>
        maybes.Any(maybe => maybe.IsNull) ?
            Null :
            maybes.Last().Value.ToMaybe();

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2)> Combine<T1, T2>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2)
    {
        if (maybe1.IsNull)
        {
            return Maybe<(T1, T2)>.Null;
        }

        if (maybe2.IsNull)
        {
            return Maybe<(T1, T2)>.Null;
        }

        return (maybe1.Value, maybe2.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3)> Combine<T1, T2, T3>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3)
    {
        var maybes = Maybe<(T1, T2)>
            .Combine(maybe1, maybe2);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3)>.Null;
        }

        if (maybe3.IsNull)
        {
            return Maybe<(T1, T2, T3)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4)
    {
        var maybes = Maybe<(T1, T2, T3)>
            .Combine(maybe1, maybe2, maybe3);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4)>.Null;
        }

        if (maybe4.IsNull)
        {
            return Maybe<(T1, T2, T3, T4)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4,
        Maybe<T5> maybe5)
    {
        var maybes = Maybe<(T1, T2, T3, T4)>
            .Combine(maybe1, maybe2, maybe3, maybe4);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5)>.Null;
        }

        if (maybe5.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5, T6)> Combine<T1, T2, T3, T4, T5, T6>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4,
        Maybe<T5> maybe5,
        Maybe<T6> maybe6)
    {
        var maybes = Maybe<(T1, T2, T3, T4, T5)>
            .Combine(maybe1, maybe2, maybe3, maybe4, maybe5);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6)>.Null;
        }

        if (maybe6.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value, maybe6.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5, T6, T7)> Combine<T1, T2, T3, T4, T5, T6, T7>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4,
        Maybe<T5> maybe5,
        Maybe<T6> maybe6,
        Maybe<T7> maybe7)
    {
        var maybes = Maybe<(T1, T2, T3, T4, T5, T6)>
            .Combine(maybe1, maybe2, maybe3, maybe4, maybe5, maybe6);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7)>.Null;
        }

        if (maybe7.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value, maybe6.Value, maybe7.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5, T6, T7, T8)> Combine<T1, T2, T3, T4, T5, T6, T7, T8>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4,
        Maybe<T5> maybe5,
        Maybe<T6> maybe6,
        Maybe<T7> maybe7,
        Maybe<T8> maybe8)
    {
        var maybes = Maybe<(T1, T2, T3, T4, T5, T6, T7)>
            .Combine(maybe1, maybe2, maybe3, maybe4, maybe5, maybe6, maybe7);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7, T8)>.Null;
        }

        if (maybe8.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7, T8)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value, maybe6.Value, maybe7.Value, maybe8.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4,
        Maybe<T5> maybe5,
        Maybe<T6> maybe6,
        Maybe<T7> maybe7,
        Maybe<T8> maybe8,
        Maybe<T9> maybe9)
    {
        var maybes = Maybe<(T1, T2, T3, T4, T5, T6, T7, T8)>
            .Combine(maybe1, maybe2, maybe3, maybe4, maybe5, maybe6, maybe7, maybe8);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>.Null;
        }

        if (maybe9.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value, maybe6.Value, maybe7.Value, maybe8.Value, maybe9.Value)
            .ToMaybe();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        Maybe<T1> maybe1,
        Maybe<T2> maybe2,
        Maybe<T3> maybe3,
        Maybe<T4> maybe4,
        Maybe<T5> maybe5,
        Maybe<T6> maybe6,
        Maybe<T7> maybe7,
        Maybe<T8> maybe8,
        Maybe<T9> maybe9,
        Maybe<T10> maybe10)
    {
        var maybes = Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
            .Combine(maybe1, maybe2, maybe3, maybe4, maybe5, maybe6, maybe7, maybe8, maybe9);

        if (maybes.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>.Null;
        }

        if (maybe10.IsNull)
        {
            return Maybe<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>.Null;
        }

        return (maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value, maybe6.Value, maybe7.Value, maybe8.Value, maybe9.Value, maybe10.Value)
            .ToMaybe();
    }
}