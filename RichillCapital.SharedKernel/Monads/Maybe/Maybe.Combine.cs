namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public static Maybe<TValue> Combine(params Maybe<TValue>[] maybes)
    {
        if (maybes.Any(maybe => maybe.IsNull))
        {
            return Null;
        }

        return maybes.Last();
    }

    public static Maybe<TValue> Combine(params Result<TValue>[] results)
    {
        if (results.Any(result => result.IsFailure))
        {
            return Null;
        }

        return results.Last().Value.ToMaybe();
    }

    public static Maybe<TValue> Combine(params ErrorOr<TValue>[] errorOrs)
    {
        if (errorOrs.Any(errorOr => errorOr.HasError))
        {
            return Null;
        }

        return errorOrs.Last().Value.ToMaybe();
    }
}