namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public static Maybe<TValue> With(TValue value) => new(value);
}