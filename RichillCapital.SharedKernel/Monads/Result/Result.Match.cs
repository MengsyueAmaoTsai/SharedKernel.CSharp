namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        if (IsFailure)
        {
            return onFailure(Error);
        }

        return onSuccess(Value);
    }
}

public readonly partial record struct Result
{
    public TResult Match<TResult>(
        Func<TResult> onSuccess,
        Func<Error, TResult> onFailure)
    {
        if (IsFailure)
        {
            return onFailure(Error);
        }

        return onSuccess();
    }
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