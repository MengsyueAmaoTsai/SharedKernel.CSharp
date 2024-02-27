namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Else(Func<Error, Error> onError) =>
       IsFailure ?
           onError(Error).ToResult<TValue>() :
           Value.ToResult();

    public Result<TValue> Else(Error error) =>
        IsFailure ?
            error.ToResult<TValue>() :
            Value.ToResult();

    public Result<TValue> Else(Func<Error, TValue> onError) =>
        IsFailure ?
            onError(Error).ToResult() :
            Value.ToResult();

    public Result<TValue> Else(TValue onError) =>
        IsFailure ?
            onError.ToResult() :
            Value.ToResult();

    public async Task<Result<TValue>> ElseAsync(Func<Error, Task<TValue>> onError) =>
        IsFailure ?
            (await onError(Error)).ToResult() :
            Value.ToResult();

    public async Task<Result<TValue>> ElseAsync(Func<Error, Task<Error>> onError) =>
        IsFailure ?
            (await onError(Error)).ToResult<TValue>() :
            Value.ToResult();

    public async Task<Result<TValue>> ElseAsync(Task<Error> error) =>
        IsFailure ?
            (await error).ToResult<TValue>() :
            Value.ToResult();

    public async Task<Result<TValue>> ElseAsync(Task<TValue> onError) =>
        IsFailure ?
            (await onError).ToResult() :
            Value.ToResult();
}

public readonly partial record struct Result
{
}