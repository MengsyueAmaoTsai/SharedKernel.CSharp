namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Then<TResult>(
        Func<TValue, TResult> valueFactory) =>
        IsFailure ?
            Error.ToResult<TResult>() :
            valueFactory(Value).ToResult();
}