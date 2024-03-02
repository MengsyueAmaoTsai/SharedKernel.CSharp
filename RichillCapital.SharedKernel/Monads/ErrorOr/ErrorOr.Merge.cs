namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Merge(params ErrorOr<TValue>[] errorOrs)
    {
        var errors = ErrorsOrEmpty
            .Concat(errorOrs
                .SelectMany(errorOr => errorOr.ErrorsOrEmpty))
            .Distinct()
            .ToArray();

        if (errors.Any())
        {
            return errors.ToErrorOr<TValue>();
        }

        return errorOrs.Last().Value.ToErrorOr();
    }
}