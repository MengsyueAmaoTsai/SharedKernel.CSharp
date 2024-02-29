namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Merge(params Result<TValue>[] results) =>
        Combine([this, .. results]);
}