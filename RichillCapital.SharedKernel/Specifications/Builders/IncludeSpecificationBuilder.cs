namespace RichillCapital.SharedKernel.Specifications.Builders;

public class IncludeSpecificationBuilder<T, TProperty> : IIncludeSpecificationBuilder<T, TProperty> where T : class
{
    public Specification<T> Specification { get; }

    public bool IsChainDiscarded { get; set; }

    public IncludeSpecificationBuilder(Specification<T> specification)
        : this(specification, false)
    {
    }

    public IncludeSpecificationBuilder(Specification<T> specification, bool isChainDiscarded)
    {
        Specification = specification;
        IsChainDiscarded = isChainDiscarded;
    }
}