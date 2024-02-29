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

public static partial class ResultExtensions
{
    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure)
    {
        var result = await resultTask;

        return result.Match(onSuccess, onFailure);
    }
}