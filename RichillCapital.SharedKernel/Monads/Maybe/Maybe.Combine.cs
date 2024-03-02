namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public static Maybe<TValue> Combine(params Maybe<TValue>[] maybes)
    {
        if (maybes.Any(maybe => maybe.IsNull))
        {
            return Null;
        }

        return maybes.Last().Value.ToMaybe();
    }
}