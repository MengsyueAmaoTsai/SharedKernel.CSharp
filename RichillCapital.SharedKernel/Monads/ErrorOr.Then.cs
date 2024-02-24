namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TResult> func) =>
        IsError ?
            ErrorOr<TResult>.From(Errors) :
            ErrorOr<TResult>.Is(func());
}

public static partial class ErrorOr
{
}