namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public static Maybe<TValue> Ensure(TValue value, Func<TValue, bool> ensure)
    {
        if (!ensure(value))
        {
            return Null;
        }

        return value.ToMaybe();
    }

    public static Maybe<TValue> Ensure(
        TValue value,
        params Func<TValue, bool>[] ensures) =>
        Ensure(value, value => ensures.All(ensure => ensure(value)));
}