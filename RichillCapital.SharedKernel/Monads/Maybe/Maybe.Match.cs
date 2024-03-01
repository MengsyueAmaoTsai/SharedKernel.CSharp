namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onHasValue,
        Func<TResult> onNull) =>
        IsNull ?
            onNull() :
            onHasValue(Value);
}