namespace RichillCapital.SharedKernel.Specifications;

public class SingleResultSpecification<T> : Specification<T>, ISingleResultSpecification<T>
{
}

public class SingleResultSpecification<T, TResult> :
    Specification<T, TResult>,
    ISingleResultSpecification<T, TResult>
{
}