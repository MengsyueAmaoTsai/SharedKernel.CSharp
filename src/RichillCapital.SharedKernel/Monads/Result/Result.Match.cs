namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
    public static TResult Match<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure) =>
        result.IsFailure ?
            onFailure(result.Error) :
            onSuccess(result.Value);

    public static async Task<TResult> Match<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, Task<TResult>> onSuccessTask,
        Func<Error, Task<TResult>> onFailureTask) =>
        result.IsFailure ?
            await onFailureTask(result.Error) :
            await onSuccessTask(result.Value);

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure)
    {
        var result = await resultTask;
        return result.Match(onSuccess, onFailure);
    }
}

public static partial class ResultExtensions
{
    public static TResult Match<TResult>(
        this Result result,
        Func<TResult> onSuccess,
        Func<Error, TResult> onFailure) =>
        result.IsFailure ?
            onFailure(result.Error) :
            onSuccess();
}