namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure) =>
        IsFailure ?
            onFailure(Error) :
            onSuccess(Value);
}