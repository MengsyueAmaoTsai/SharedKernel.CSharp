namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public async Task<Maybe<TResult>> Then<TResult>(Func<TValue, Task<Maybe<TResult>>> maybeTask)
    {
        if (HasNoValue)
        {
            return Maybe<TResult>.Null;
        }

        var maybeResult = await maybeTask(Value);

        return Maybe<TResult>.Have(maybeResult.Value);
    }

    public Maybe<TResult> Then<TResult>(Func<TResult> factory) =>
        HasNoValue ?
            Maybe<TResult>.Null :
            Maybe<TResult>.Have(factory());
}