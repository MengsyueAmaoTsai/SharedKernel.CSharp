namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TResult> Then<TResult>(Func<TValue, Maybe<TResult>> onValue) =>
         HasNoValue ?
             Maybe<TResult>.Null :
             onValue(Value);

    public async Task<Maybe<TResult>> Then<TResult>(Func<TValue, Task<Maybe<TResult>>> onValueTask) =>
        HasNoValue ?
            Maybe<TResult>.Null :
            await onValueTask(Value);

    public Maybe<TValue> Then(Action<TValue> onValue)
    {
        if (HasNoValue)
        {
            return Null;
        }

        onValue(Value);

        return _value.ToMaybe();
    }

    public async Task<Maybe<TValue>> Then(Func<TValue, Task> onValueTask)
    {
        if (HasNoValue)
        {
            return Null;
        }

        await onValueTask(Value);

        return _value.ToMaybe();
    }

    public Maybe<TResult> Then<TResult>(Func<TValue, TResult> onValue) =>
        HasNoValue ?
            Maybe<TResult>.Null :
            onValue(Value).ToMaybe();

    public async Task<Maybe<TResult>> Then<TResult>(Func<TValue, Task<TResult>> onValueTask) =>
        HasNoValue ?
            Maybe<TResult>.Null :
            await onValueTask(Value).ToMaybe();
}