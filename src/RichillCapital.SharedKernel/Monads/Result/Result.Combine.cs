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
    public static Result<(T1, T2)> Combine<T1, T2>(
        Result<T1> result1,
        Result<T2> result2)
    {
        if (result1.IsFailure)
        {
            return result1.Error.ToResult<(T1, T2)>();
        }

        if (result2.IsFailure)
        {
            return result2.Error.ToResult<(T1, T2)>();
        }

        return (result1.Value, result2.Value).ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3)> Combine<T1, T2, T3>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3)
    {
        var results = Result<(T1, T2)>
            .Combine(result1, result2);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3)>();
        }

        if (result3.IsFailure)
        {
            return result3.Error.ToResult<(T1, T2, T3)>();
        }

        return (result1.Value, result2.Value, result3.Value).ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4)
    {
        var results = Result<(T1, T2, T3)>
            .Combine(result1, result2, result3);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4)>();
        }

        if (result4.IsFailure)
        {
            return result4.Error.ToResult<(T1, T2, T3, T4)>();
        }

        return (result1.Value, result2.Value, result3.Value, result4.Value)
            .ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4,
        Result<T5> result5)
    {
        var results = Result<(T1, T2, T3, T4)>
            .Combine(result1, result2, result3, result4);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4, T5)>();
        }

        if (result5.IsFailure)
        {
            return result5.Error.ToResult<(T1, T2, T3, T4, T5)>();
        }

        return (result1.Value, result2.Value, result3.Value, result4.Value, result5.Value)
            .ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5, T6)> Combine<T1, T2, T3, T4, T5, T6>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4,
        Result<T5> result5,
        Result<T6> result6)
    {
        var results = Result<(T1, T2, T3, T4, T5)>
            .Combine(result1, result2, result3, result4, result5);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4, T5, T6)>();
        }

        if (result6.IsFailure)
        {
            return result6.Error.ToResult<(T1, T2, T3, T4, T5, T6)>();
        }

        return (
            result1.Value,
            result2.Value,
            result3.Value,
            result4.Value,
            result5.Value,
            result6.Value)
            .ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5, T6, T7)> Combine<T1, T2, T3, T4, T5, T6, T7>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4,
        Result<T5> result5,
        Result<T6> result6,
        Result<T7> result7)
    {
        var results = Result<(T1, T2, T3, T4, T5, T6)>
            .Combine(result1, result2, result3, result4, result5, result6);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7)>();
        }

        if (result7.IsFailure)
        {
            return result7.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7)>();
        }

        return (
            result1.Value,
            result2.Value,
            result3.Value,
            result4.Value,
            result5.Value,
            result6.Value,
            result7.Value)
            .ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5, T6, T7, T8)> Combine<T1, T2, T3, T4, T5, T6, T7, T8>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4,
        Result<T5> result5,
        Result<T6> result6,
        Result<T7> result7,
        Result<T8> result8)
    {
        var results = Result<(T1, T2, T3, T4, T5, T6, T7)>
            .Combine(result1, result2, result3, result4, result5, result6, result7);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7, T8)>();
        }

        if (result8.IsFailure)
        {
            return result8.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7, T8)>();
        }

        return (
            result1.Value,
            result2.Value,
            result3.Value,
            result4.Value,
            result5.Value,
            result6.Value,
            result7.Value,
            result8.Value)
            .ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4,
        Result<T5> result5,
        Result<T6> result6,
        Result<T7> result7,
        Result<T8> result8,
        Result<T9> result9)
    {
        var results = Result<(T1, T2, T3, T4, T5, T6, T7, T8)>
            .Combine(result1, result2, result3, result4, result5, result6, result7, result8);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>();
        }

        if (result9.IsFailure)
        {
            return result9.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>();
        }

        return (
            result1.Value,
            result2.Value,
            result3.Value,
            result4.Value,
            result5.Value,
            result6.Value,
            result7.Value,
            result8.Value,
            result9.Value)
            .ToResult();
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        Result<T1> result1,
        Result<T2> result2,
        Result<T3> result3,
        Result<T4> result4,
        Result<T5> result5,
        Result<T6> result6,
        Result<T7> result7,
        Result<T8> result8,
        Result<T9> result9,
        Result<T10> result10)
    {
        var results = Result<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
            .Combine(result1, result2, result3, result4, result5, result6, result7, result8, result9);

        if (results.IsFailure)
        {
            return results.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>();
        }

        if (result10.IsFailure)
        {
            return result10.Error.ToResult<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>();
        }

        return (result1.Value, result2.Value, result3.Value, result4.Value, result5.Value, result6.Value, result7.Value, result8.Value, result9.Value, result10.Value).ToResult();
    }
}

public readonly partial record struct Result
{
}