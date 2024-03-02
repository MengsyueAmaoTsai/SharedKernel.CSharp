namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public static Maybe<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure) =>
        !ensure(value) ?
            Null :
            value.ToMaybe();

    public Maybe<TValue> Ensure(
        Func<TValue, bool> ensure) =>
        IsNull ?
            Null :
            !ensure(Value) ?
                Null :
                Value.ToMaybe();
}