namespace RichillCapital.SharedKernel.Monad;

public partial record class Result<TValue> : Result
{
    public Result<TDestination> Map<TDestination>(Func<TValue, TDestination> map) =>
        IsFailure ?
            Result<TDestination>.Failure(Error) :
            map(Value);
}
