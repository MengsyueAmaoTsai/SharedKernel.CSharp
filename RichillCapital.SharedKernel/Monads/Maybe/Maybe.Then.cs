namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TResult> Then<TResult>(Func<TValue, TResult> resultFactory) =>
        IsNull ?
            Maybe<TResult>.Null :
            resultFactory(Value).ToMaybe();

    public Maybe<TResult> Then<TResult>(Func<TResult> resultFactory) =>
        IsNull ?
            Maybe<TResult>.Null :
            resultFactory().ToMaybe();

    public Maybe<TValue> Then(Action<TValue> action)
    {
        if (IsNull)
        {
            return Null;
        }

        action(Value);

        return Value.ToMaybe();
    }

    public async Task<Maybe<TResult>> Then<TResult>(Func<TValue, Task<Maybe<TResult>>> maybeFactoryTask) =>
        IsNull ?
            Maybe<TResult>.Null :
            await maybeFactoryTask(Value).ConfigureAwait(false);
}