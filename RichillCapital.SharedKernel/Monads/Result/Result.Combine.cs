using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    /// <summary>
    /// Combines multiple <see cref="Result{TValue}"/> instances into a single <see cref="Result{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Combine(params Result<TValue>[] results) =>
        results.Any(result => result.IsFailure) ?
            results
                .Where(result => result.IsFailure)
                .Select(result => result.Error)
                .ToArray()
                .Distinct()
                .First()
                .ToResult<TValue>() :
            results.Last().Value.ToResult();

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2)> Combine<T1, T2>(Result<T1> errorOr1, Result<T2> errorOr2)
    {
        if (errorOr1.IsFailure)
        {
            return errorOr1.Error.ToResult<(T1, T2)>();
        }

        if (errorOr2.IsFailure)
        {
            return errorOr2.Error.ToResult<(T1, T2)>();
        }

        return (errorOr1.Value, errorOr2.Value).ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3)> Combine<T1, T2, T3>(Result<T1> errorOr1, Result<T2> errorOr2, Result<T3> errorOr3)
    {
        var errorOrs = Result<(T1, T2)>
            .Combine(errorOr1, errorOr2);

        if (errorOrs.IsFailure)
        {
            return errorOrs.Error.ToResult<(T1, T2, T3)>();
        }

        if (errorOr3.IsFailure)
        {
            return errorOr3.Error.ToResult<(T1, T2, T3)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value).ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(Result<T1> errorOr1, Result<T2> errorOr2, Result<T3> errorOr3, Result<T4> errorOr4)
    {
        var errorOrs = Result<(T1, T2, T3)>
            .Combine(errorOr1, errorOr2, errorOr3);

        if (errorOrs.IsFailure)
        {
            return errorOrs.Error.ToResult<(T1, T2, T3, T4)>();
        }

        if (errorOr4.IsFailure)
        {
            return errorOr4.Error.ToResult<(T1, T2, T3, T4)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value).ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(Result<T1> errorOr1, Result<T2> errorOr2, Result<T3> errorOr3, Result<T4> errorOr4, Result<T5> errorOr5)
    {
        var errorOrs = Result<(T1, T2, T3, T4)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4);

        if (errorOrs.IsFailure)
        {
            return errorOrs.Error.ToResult<(T1, T2, T3, T4, T5)>();
        }

        if (errorOr5.IsFailure)
        {
            return errorOr5.Error.ToResult<(T1, T2, T3, T4, T5)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value).ToResult();
    }
}

public readonly partial record struct Result
{
}