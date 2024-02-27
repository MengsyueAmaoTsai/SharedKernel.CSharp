namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onHasValue,
        Func<TResult> onNoValue) =>
        HasNoValue ?
            onNoValue() :
            onHasValue(Value);

    public async Task<TResult> Match<TResult>(
        Func<TValue, Task<TResult>> onHasValue,
        Func<Task<TResult>> onNoValue) =>
        HasNoValue ?
            await onNoValue() :
            await onHasValue(Value);
}