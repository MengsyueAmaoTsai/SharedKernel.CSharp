namespace RichillCapital.SharedKernel.Specifications;

public interface ISingleResultSpecification<T> : ISpecification<T>
{
}

public interface ISingleResultSpecification<T, TResult> :
    ISpecification<T, TResult>
{
}