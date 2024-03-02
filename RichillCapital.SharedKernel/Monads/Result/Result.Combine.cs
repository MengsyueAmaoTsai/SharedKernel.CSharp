namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public static Result<TValue> Combine(params Result<TValue>[] results)
    {
        if (results.Any(result => result.IsFailure))
        {
            return results
                .Where(result => result.IsFailure)
                .Select(result => result.Error)
                .ToArray()
                .Distinct()
                .First()
                .ToResult<TValue>();
        }

        return results.Last().Value.ToResult();
    }
}

public readonly partial record struct Result
{
}