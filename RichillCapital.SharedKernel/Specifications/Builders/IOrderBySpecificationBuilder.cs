namespace RichillCapital.SharedKernel.Specifications.Builders;

public interface IOrderedSpecificationBuilder<T> : ISpecificationBuilder<T>
{
    bool IsChainDiscarded { get; set; }
}