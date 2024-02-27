namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TResult> Map<TResult>(
        Func<TValue, TResult> map) =>
        HasNoValue ?
            Maybe<TResult>.Null :
            Maybe<TResult>.Have(map(_value));
}