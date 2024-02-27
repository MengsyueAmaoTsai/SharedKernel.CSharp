namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public void Switch(
        Action<TValue> onHasValue,
        Action onHasNoValue)
    {
        if (HasValue)
        {
            onHasValue(Value);
        }
        else
        {
            onHasNoValue();
        }
    }

}