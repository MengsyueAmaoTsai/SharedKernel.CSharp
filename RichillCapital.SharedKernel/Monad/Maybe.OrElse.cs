namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> OrElse(TValue value) =>
        HasValue ? Value : Maybe<TValue>.With(value);
}