namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
}

public static partial class ErrorOrExtensions
{
    public static ErrorOr<TValue> Else<TValue>(
        this ErrorOr<TValue> errorOr,
        TValue elseValue)
    {
        if (errorOr.HasError)
        {
            return elseValue.ToErrorOr();
        }

        return errorOr.Value.ToErrorOr();
    }
}