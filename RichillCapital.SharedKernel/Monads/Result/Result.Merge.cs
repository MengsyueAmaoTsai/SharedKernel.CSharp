using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Merge(params Result<TValue>[] results)
    {
        if (IsFailure)
        {
            return Error.ToResult<TValue>();
        }

        if (results.Any(result => result.IsFailure))
        {
            return results
                .First(result => result.IsFailure).Error
                .ToResult<TValue>();
        }

        return results.Last().Value.ToResult();
    }
}

public readonly partial record struct Result
{
}