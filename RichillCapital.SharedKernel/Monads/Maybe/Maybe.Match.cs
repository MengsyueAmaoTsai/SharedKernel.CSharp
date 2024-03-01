namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onHasValue,
        Func<TResult> onIsNull) =>
        IsNull ?
            onIsNull() :
            onHasValue(Value);
}