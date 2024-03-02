namespace RichillCapital.SharedKernel.Monads;

public static partial class ErrorOrExtensions
{
    public static ErrorOr<TValue> ThrowIfError<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.HasError ?
            throw new InvalidOperationException(errorOr.Errors.First().Message) :
            errorOr;

    public static async Task<ErrorOr<TValue>> ThrowIfError<TValue>(
        this Task<ErrorOr<TValue>> errorOrTask)
    {
        var errorOr = await errorOrTask;

        return errorOr.ThrowIfError();
    }
}