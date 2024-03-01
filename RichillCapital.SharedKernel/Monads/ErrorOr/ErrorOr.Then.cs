namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> factory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            factory(Value).ToErrorOr();
}