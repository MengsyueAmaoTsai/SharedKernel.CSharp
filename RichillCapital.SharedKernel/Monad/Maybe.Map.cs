namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TDestination> Map<TDestination>(Func<TValue, TDestination> map) =>
        HasValue ?
            Maybe<TDestination>.With(map(Value)) :
            Maybe<TDestination>.Null;
}