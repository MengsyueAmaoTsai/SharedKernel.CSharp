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

        return errorOrs.Last().Value.ToErrorOr();
    }
}