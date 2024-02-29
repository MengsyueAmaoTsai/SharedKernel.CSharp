namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> resultFactory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            resultFactory(Value).ToErrorOr();

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
