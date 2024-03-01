namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Ensure(
    Func<TValue, bool> ensure) =>
        IsNull ?
            Null :
            !ensure(Value) ?
                Null :
                Value.ToMaybe();
}