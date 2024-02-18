namespace RichillCapital.SharedKernel.Specifications.Builders;

public interface IIncludeSpecificationBuilder<T, out TProperty> :
    ISpecificationBuilder<T>
    where T : class
{
    bool IsChainDiscarded { get; set; }
}