namespace RichillCapital.SharedKernel.Monads;

public static partial class ResultExtensions
{
    public static async Task<Result<TResult>> Map<TValue, TResult>(
    this Task<Result<TValue>> resultTask,
    Func<TValue, TResult> map)
    {
        var result = await resultTask;

        return result.IsFailure ?
            Result<TResult>.Failure(result.Error) :
            Result<TResult>.Success(map(result.Value));
    }

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Result<TValue>> errorOrTask,
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onError)
    {
        var errorOr = await errorOrTask;

        return errorOr.IsFailure ?
            onError(errorOr.Error) :
            onSuccess(errorOr.Value);
    }
}