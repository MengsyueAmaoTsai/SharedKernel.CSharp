namespace RichillCapital.SharedKernel.Monad;

public partial record class Result<TValue> : Result
{
    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<TResult>> func) =>
        IsFailure ?
            Result<TResult>.Failure(Error) :
            await func(Value);
}
