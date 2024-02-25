namespace RichillCapital.SharedKernel.Monads;

public static partial class ResultExtensions
{
    public static Result<TValue> ToResult<TValue>(this TValue value) => Result<TValue>.Success(value);

    public static Result<TValue> ToResult<TValue>(this Error error) => Result<TValue>.Failure(error);
}