namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public TResult Match<TResult>(
        Func<IEnumerable<Error>, TResult> onError,
        Func<TValue, TResult> onValue) =>
        HasError ?
            onError(Errors) :
            onValue(Value);
}
