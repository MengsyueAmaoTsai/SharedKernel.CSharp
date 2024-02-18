namespace RichillCapital.SharedKernel.Specifications.Builders;

public class OrderedSpecificationBuilder<T> : IOrderedSpecificationBuilder<T>
{
    public OrderedSpecificationBuilder(Specification<T> specification)
        : this(specification, false)
    {
    }

    public OrderedSpecificationBuilder(
        Specification<T> specification,
        bool isChainDiscarded) =>
        (Specification, IsChainDiscarded) = (specification, isChainDiscarded);

    public Specification<T> Specification { get; }

    public bool IsChainDiscarded { get; set; }
}