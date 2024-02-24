namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Then(Action<TValue> action)
    {
        if (IsError)
        {
            return ErrorOr<TValue>.From(Errors);
        }

        action(Value);

        return ErrorOr<TValue>.Is(Value);
    }

    public ErrorOr<TValue> Then(Action action)
    {
        if (IsError)
        {
            return ErrorOr<TValue>.From(Errors);
        }

        action();

        return ErrorOr<TValue>.Is(Value);
    }

    public ErrorOr<TResult> Then<TResult>(Func<TResult> func) =>
        IsError ?
            ErrorOr<TResult>.From(Errors) :
            ErrorOr<TResult>.Is(func());
}

public static partial class ErrorOr
{
}