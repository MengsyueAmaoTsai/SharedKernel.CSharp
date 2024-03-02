namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Merge(params Maybe<TValue>[] maybes)
    {
        if (IsNull)
        {
            return Null;
        }

        if (maybes.Any(maybe => maybe.IsNull))
        {
            return Null;
        }

        return maybes.Last().Value.ToMaybe();
    }
}