namespace RichillCapital.SharedKernel.Monads;

public static partial class ResultExtensions
{
    public static Result<TValue> ThrowIfFailure<TValue>(this Result<TValue> result) =>
        result.IsFailure ?
            throw new InvalidOperationException(result.Error.Message) :
            result;

    public static async Task<Result<TValue>> ThrowIfFailure<TValue>(
        this Task<Result<TValue>> resultTask)
    {
        var result = await resultTask;

        return result.ThrowIfFailure();
    }
}