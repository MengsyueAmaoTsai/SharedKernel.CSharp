namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> resultFactory)
    {
        if (HasError)
        {
            return Errors.ToErrorOr<TResult>();
        }

        return resultFactory(Value).ToErrorOr();
    }
}
