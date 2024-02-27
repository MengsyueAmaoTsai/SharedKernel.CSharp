namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> OrElse(TValue value) =>
        HasNoValue ?
            Maybe<TValue>.Have(value) :
            Maybe<TValue>.Have(_value);
}