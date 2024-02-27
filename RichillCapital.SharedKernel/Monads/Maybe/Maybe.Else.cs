namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    // public Maybe<TValue> Else(Func<IEnumerable<Error>, Error> onError) =>
    //        HasNoValue ?
    //            onError(Errors).ToMaybe<TValue>() :
    //            Value.ToMaybe();

    // public Maybe<TValue> Else(Func<List<Error>, List<Error>> onError) =>
    //     HasNoValue ?
    //         Value.ToMaybe() :
    //         onError(Errors).ToMaybe<TValue>();

    // public Maybe<TValue> Else(Error error) =>
    //     HasNoValue ?
    //         error.ToMaybe<TValue>() :
    //         Value.ToMaybe();

    // public Maybe<TValue> Else(Func<List<Error>, TValue> onError) =>
    //     HasNoValue ?
    //         onError(Errors).ToMaybe() :
    //         Value.ToMaybe();

    public Maybe<TValue> Else(TValue onError) =>
        HasNoValue ?
            onError.ToMaybe() :
            Value.ToMaybe();

    // public async Task<Maybe<TValue>> ElseAsync(Func<List<Error>, Task<TValue>> onError) =>
    //     HasNoValue ?
    //         (await onError(Errors)).ToMaybe() :
    //         Value.ToMaybe();

    // public async Task<Maybe<TValue>> ElseAsync(Func<List<Error>, Task<Error>> onError) =>
    //     HasNoValue ?
    //         (await onError(Errors)).ToMaybe<TValue>() :
    //         Value.ToMaybe();

    // public async Task<Maybe<TValue>> ElseAsync(Func<List<Error>, Task<List<Error>>> onError) =>
    //     HasNoValue ?
    //         (await onError(Errors)).ToMaybe<TValue>() :
    //         Value.ToMaybe();

    // public async Task<Maybe<TValue>> ElseAsync(Task<Error> error) =>
    //     HasNoValue ?
    //         (await error).ToMaybe<TValue>() :
    //         Value.ToMaybe();

    public async Task<Maybe<TValue>> ElseAsync(Task<TValue> onNoValue) =>
        HasNoValue ?
            (await onNoValue).ToMaybe() :
            Value.ToMaybe();
}