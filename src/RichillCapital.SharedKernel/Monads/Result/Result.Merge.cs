namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
    public static Result<TValue> Merge<TValue>(
        this Result<TValue> result,
        params Result<TValue>[] results) =>
        result.IsFailure ?
            result.Error.ToResult<TValue>() :
            results.Any(result => result.IsFailure) ?
                results.First(result => result.IsFailure).Error.ToResult<TValue>() :
                results.Last().Value.ToResult();
}