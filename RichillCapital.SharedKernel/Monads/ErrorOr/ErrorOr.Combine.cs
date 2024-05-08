using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Combine(params ErrorOr<TValue>[] errorOrs)
    {
        if (errorOrs.Any(errorOr => errorOr.HasError))
        {
            return errorOrs
                .Where(errorOr => errorOr.HasError)
                .SelectMany(errorOr => errorOr.Errors)
                .Distinct()
                .ToArray()
                .ToErrorOr<TValue>();
        }

        return errorOrs.Last().Value
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2)> Combine<T1, T2>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2)
    {
        if (errorOr1.HasError)
        {
            return errorOr1.Errors.ToErrorOr<(T1, T2)>();
        }

        if (errorOr2.HasError)
        {
            return errorOr2.Errors.ToErrorOr<(T1, T2)>();
        }

        return (errorOr1.Value, errorOr2.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3)> Combine<T1, T2, T3>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3)
    {
        var errorOrs = ErrorOr<(T1, T2)>
            .Combine(errorOr1, errorOr2);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3)>();
        }

        if (errorOr3.HasError)
        {
            return errorOr3.Errors.ToErrorOr<(T1, T2, T3)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4)
    {
        var errorOrs = ErrorOr<(T1, T2, T3)>
            .Combine(errorOr1, errorOr2, errorOr3);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4)>();
        }

        if (errorOr4.HasError)
        {
            return errorOr4.Errors.ToErrorOr<(T1, T2, T3, T4)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4,
        ErrorOr<T5> errorOr5)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5)>();
        }

        if (errorOr5.HasError)
        {
            return errorOr5.Errors.ToErrorOr<(T1, T2, T3, T4, T5)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4, T5, T6)> Combine<T1, T2, T3, T4, T5, T6>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4,
        ErrorOr<T5> errorOr5,
        ErrorOr<T6> errorOr6)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4, T5)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4, errorOr5);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6)>();
        }

        if (errorOr6.HasError)
        {
            return errorOr6.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value, errorOr6.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4, T5, T6, T7)> Combine<T1, T2, T3, T4, T5, T6, T7>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4,
        ErrorOr<T5> errorOr5,
        ErrorOr<T6> errorOr6,
        ErrorOr<T7> errorOr7)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4, T5, T6)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4, errorOr5, errorOr6);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7)>();
        }

        if (errorOr7.HasError)
        {
            return errorOr7.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value, errorOr6.Value, errorOr7.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8)> Combine<T1, T2, T3, T4, T5, T6, T7, T8>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4,
        ErrorOr<T5> errorOr5,
        ErrorOr<T6> errorOr6,
        ErrorOr<T7> errorOr7,
        ErrorOr<T8> errorOr8)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4, T5, T6, T7)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4, errorOr5, errorOr6, errorOr7);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8)>();
        }

        if (errorOr8.HasError)
        {
            return errorOr8.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value, errorOr6.Value, errorOr7.Value, errorOr8.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4,
        ErrorOr<T5> errorOr5,
        ErrorOr<T6> errorOr6,
        ErrorOr<T7> errorOr7,
        ErrorOr<T8> errorOr8,
        ErrorOr<T9> errorOr9)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4, errorOr5, errorOr6, errorOr7, errorOr8);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>();
        }

        if (errorOr9.HasError)
        {
            return errorOr9.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value, errorOr6.Value, errorOr7.Value, errorOr8.Value, errorOr9.Value)
            .ToErrorOr();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        ErrorOr<T1> errorOr1,
        ErrorOr<T2> errorOr2,
        ErrorOr<T3> errorOr3,
        ErrorOr<T4> errorOr4,
        ErrorOr<T5> errorOr5,
        ErrorOr<T6> errorOr6,
        ErrorOr<T7> errorOr7,
        ErrorOr<T8> errorOr8,
        ErrorOr<T9> errorOr9,
        ErrorOr<T10> errorOr10)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4, errorOr5, errorOr6, errorOr7, errorOr8, errorOr9);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>();
        }

        if (errorOr10.HasError)
        {
            return errorOr10.Errors.ToErrorOr<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value, errorOr6.Value, errorOr7.Value, errorOr8.Value, errorOr9.Value, errorOr10.Value)
            .ToErrorOr();
    }
}