namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Then(Action action)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TValue>();
        }

        action();

        return Value.ToErrorOr();
    }

    public ErrorOr<TValue> Then(Action<TValue> actionWithValue)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TValue>();
        }

        actionWithValue(Value);

        return Value.ToErrorOr();
    }

    public ErrorOr<TResult> Then<TResult>(Func<TResult> factory)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TResult>();
        }

        return factory().ToErrorOr();
    }

    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> factoryWithValue)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TResult>();
        }

        return factoryWithValue(Value).ToErrorOr();
    }
}

public static partial class ErrorOrExtensions
{
}