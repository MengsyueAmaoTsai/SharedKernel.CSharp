namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public static Result<TValue> Combine(params Result<TValue>[] results)
    {
        if (results.Any(result => result.IsFailure))
        {
            return results
                .First(result => result.IsFailure).Error
                .ToResult<TValue>();
        }

        return results.Last();
    }

    public static Result<TValue> Combine(params ErrorOr<TValue>[] errorOrs)
    {
        if (errorOrs.Any(errorOr => errorOr.HasError))
        {
            return errorOrs
                .First(errorOr => errorOr.HasError)
                .Errors.First()
                .ToResult<TValue>();
        }

        return errorOrs.Last().Value.ToResult();
    }
}