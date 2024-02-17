using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications;

public abstract class Specification<T, TProperty>
{
}

public abstract class Specification<T>
{
    protected Specification()
    {
        Query = new SpecificationBuilder<T>(this);
    }

    public virtual SpecificationBuilder<T> Query { get; private init; }

    public IEnumerable<Expression<Func<T, object>>> IncludeExpressions { get; } = [];

    public IEnumerable<Expression<Func<T, bool>>> WhereExpressions { get; } = [];

    public IEnumerable<Expression<Func<T, object>>> OrderExpressions { get; } = [];

    public Func<IEnumerable<T>, IEnumerable<T>>? PostProcessingAction { get; internal set; } = null;

    public int? Take { get; internal set; }

    public int? Skip { get; internal set; }

    public bool AsTracking { get; internal set; } = false;

    public bool AsNoTracking { get; internal set; } = false;

    public bool AsSplitQuery { get; internal set; } = false;

    public bool AsNoTrackingWithIdentityResolution { get; internal set; } = false;

    public bool IgnoreQueryFilters { get; internal set; } = false;
}
