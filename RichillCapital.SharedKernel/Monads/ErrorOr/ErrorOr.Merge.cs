namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Merge(params ErrorOr<TValue>[] errorOrs) =>
        Combine([this, .. errorOrs]);
}