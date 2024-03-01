namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public TResult Match<TResult>(
        Func<IEnumerable<Error>, TResult> onHasError,
        Func<TValue, TResult> onIsValue)
    {
        if (HasError)
        {
            return onHasError(Errors);
        }

        return onIsValue(Value);
    }
}