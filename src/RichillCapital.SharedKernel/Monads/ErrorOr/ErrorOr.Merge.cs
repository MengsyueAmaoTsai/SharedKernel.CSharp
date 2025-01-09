namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
}

public static partial class ErrorOrExtensions
{
    /// <summary>
    /// Merges an <see cref="ErrorOr{TValue}"/> with a collection of <see cref="ErrorOr{TValue}"/>s.
    /// </summary>
    public static ErrorOr<TValue> Merge<TValue>(
        this ErrorOr<TValue> errorOr,
        params ErrorOr<TValue>[] errorOrs)
    {
        var errors = errorOr.ErrorsOrEmpty
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