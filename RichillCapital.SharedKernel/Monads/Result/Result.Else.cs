namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
    public static Result<TValue> Else<TValue>(
        this Result<TValue> result,
        TValue elseValue) =>
        result.IsFailure ?
            elseValue.ToResult() :
            result.Value.ToResult();
}