using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    /// <summary>
    /// Create a success result if the given predicate is true, otherwise create a failure result with the given error.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            error.ToResult<TValue>() :
            value.ToResult();

    /// <summary>
    /// Create a success result if the given predicates are true,
    /// otherwise create a failure result with the first error.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        params (Func<TValue, bool> predicate, Error error)[] rules)
    {
        foreach (var (predicate, error) in rules)
        {
            if (!predicate(value))
            {
                return error.ToResult<TValue>();
            }
        }

        return value.ToResult();
    }
}