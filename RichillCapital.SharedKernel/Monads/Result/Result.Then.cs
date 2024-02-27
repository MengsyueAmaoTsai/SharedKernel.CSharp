namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<Result<TResult>>> resultTask)
    {
        if (IsFailure)
        {
            return Result<TResult>.Failure(_error);
        }

        var result = await resultTask(Value);

        return Result<TResult>.Success(result.Value);
    }

    public Result<TResult> Then<TResult>(Func<TResult> factory) =>
        IsFailure ?
            Result<TResult>.Failure(_error) :
            Result<TResult>.Success(factory());
}

public readonly partial record struct Result
{
}