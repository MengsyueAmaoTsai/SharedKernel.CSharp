namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TDestination> Map<TDestination>(Func<TValue, TDestination> map) =>
        IsError ?
            ErrorOr<TDestination>.From(Errors) :
            ErrorOr<TDestination>.Is(map(Value));
}

public readonly partial record struct ErrorOr
{
}