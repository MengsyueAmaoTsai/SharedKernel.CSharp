namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Ensure(
        Func<TValue, bool> ensure) =>
        HasNoValue ?
            Null :
            ensure(_value) ?
                Maybe<TValue>.Have(_value) :
                Null;
}