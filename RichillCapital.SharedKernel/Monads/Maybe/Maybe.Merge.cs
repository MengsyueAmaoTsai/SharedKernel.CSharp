namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Merge(params Maybe<TValue>[] maybes) =>
        Combine([this, .. maybes]);
}