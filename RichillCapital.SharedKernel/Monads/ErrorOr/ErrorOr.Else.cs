namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Else(Func<IEnumerable<Error>, Error> onError) =>
        IsError ?
            onError(Errors).ToErrorOr<TValue>() :
            Value.ToErrorOr();

    public ErrorOr<TValue> Else(Func<List<Error>, List<Error>> onError) =>
        IsError ?
            Value.ToErrorOr() :
            onError(Errors).ToErrorOr<TValue>();

    public ErrorOr<TValue> Else(Error error) =>
        IsError ?
            error.ToErrorOr<TValue>() :
            Value.ToErrorOr();

    public ErrorOr<TValue> Else(Func<List<Error>, TValue> onError) =>
        IsError ?
            onError(Errors).ToErrorOr() :
            Value.ToErrorOr();

    public ErrorOr<TValue> Else(TValue onError) =>
        IsError ?
            onError.ToErrorOr() :
            Value.ToErrorOr();

    public async Task<ErrorOr<TValue>> ElseAsync(Func<List<Error>, Task<TValue>> onError) =>
        IsError ?
            (await onError(Errors)).ToErrorOr() :
            Value.ToErrorOr();

    public async Task<ErrorOr<TValue>> ElseAsync(Func<List<Error>, Task<Error>> onError) =>
        IsError ?
            (await onError(Errors)).ToErrorOr<TValue>() :
            Value.ToErrorOr();

    public async Task<ErrorOr<TValue>> ElseAsync(Func<List<Error>, Task<List<Error>>> onError) =>
        IsError ?
            (await onError(Errors)).ToErrorOr<TValue>() :
            Value.ToErrorOr();

    public async Task<ErrorOr<TValue>> ElseAsync(Task<Error> error) =>
        IsError ?
            (await error).ToErrorOr<TValue>() :
            Value.ToErrorOr();

    public async Task<ErrorOr<TValue>> ElseAsync(Task<TValue> onError) =>
        IsError ?
            (await onError).ToErrorOr() :
            Value.ToErrorOr();
}