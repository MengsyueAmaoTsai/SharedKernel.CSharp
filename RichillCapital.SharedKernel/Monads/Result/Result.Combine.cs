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
}

public readonly partial record struct Result
{
}