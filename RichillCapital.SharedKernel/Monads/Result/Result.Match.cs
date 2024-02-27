namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure) =>
        IsSuccess ?
            onSuccess(_value) :
            onFailure(_error);

    public async Task<TResult> Match<TResult>(
        Func<TValue, Task<TResult>> onSuccess,
        Func<Error, Task<TResult>> onFailure) =>
        IsSuccess ?
            await onSuccess(_value) :
            await onFailure(_error);
}

public readonly partial record struct Result
{
}