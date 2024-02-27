namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> errorOrTask)
    {
        if (IsError)
        {
            return ErrorOr<TResult>.Is(_errors.ToArray());
        }

        var errorOrResult = await errorOrTask(Value);

        return ErrorOr<TResult>
            .Is(errorOrResult.Value);
    }

    public ErrorOr<TResult> Then<TResult>(Func<TResult> factory) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors) :
            ErrorOr<TResult>.Is(factory());
}