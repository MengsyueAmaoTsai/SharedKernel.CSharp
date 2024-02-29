namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
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

        return errorOrs.Last();
    }

    public static ErrorOr<TValue> Combine(params Result<TValue>[] results)
    {
        if (results.Any(result => result.IsFailure))
        {
            return results
                .Where(result => result.IsFailure)
                .Select(result => result.Error)
                .Distinct()
                .ToArray()
                .ToErrorOr<TValue>();
        }

        return results.Last().Value.ToErrorOr();
    }
}
