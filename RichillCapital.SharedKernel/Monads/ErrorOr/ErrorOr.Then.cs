namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> factory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            factory(Value).ToErrorOr();

    public ErrorOr<TValue> Then(Action<TValue> action)
    {
        if (HasError)
        {
            return Errors.ToErrorOr<TValue>();
        }

        action(Value);
        return Value.ToErrorOr();
    }
}

public static partial class ErrorOrExtensions
{
}