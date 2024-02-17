using RichillCapital.SharedKernel.Specifications.Expressions;

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

    public IDictionary<string, object> Items { get; private init; } = new Dictionary<string, object>();

    public virtual SpecificationBuilder<T> Query { get; private init; }

    public IEnumerable<WhereExpression<T>> WhereExpressions { get; } = [];

    public IEnumerable<OrderByExpression<T>> OrderByExpressions { get; private init; } = [];

    public IEnumerable<IncludeExpression> IncludeExpressions { get; } = [];

    public IEnumerable<string> IncludeStrings { get; private init; } = [];

    public IEnumerable<SearchExpression<T>> SearchExpressions { get; private init; } = [];

    public Func<IEnumerable<T>, IEnumerable<T>>? PostProcessingAction { get; internal set; } = null;

    public int? Take { get; internal set; }

    public int? Skip { get; internal set; }

    public bool AsTracking { get; internal set; } = false;

    public bool AsNoTracking { get; internal set; } = false;

    public bool AsSplitQuery { get; internal set; } = false;

    public bool AsNoTrackingWithIdentityResolution { get; internal set; } = false;

    public bool IgnoreQueryFilters { get; internal set; } = false;
}
