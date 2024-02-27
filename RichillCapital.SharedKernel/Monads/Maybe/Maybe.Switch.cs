namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public void Switch(
           Action<TValue> onValue,
           Action onNoValue)
    {
        if (HasNoValue)
        {
            onNoValue();
            return;
        }

        onValue(Value);
    }

    public async Task Switch(
        Func<TValue, Task> onValue,
        Func<Task> onNoValue)
    {
        if (HasNoValue)
        {
            await onNoValue();
            return;
        }

        await onValue(Value);
    }
}