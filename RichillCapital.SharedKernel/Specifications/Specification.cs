using System.Linq.Expressions;

using RichillCapital.SharedKernel.Specifications.Expressions;

namespace RichillCapital.SharedKernel.Specifications;

public abstract class Specification<T, TResult> : Specification<T>
{
    protected Specification()
    {
        Query = new SpecificationBuilder<T, TResult>(this);
    }

    public new virtual SpecificationBuilder<T, TResult> Query { get; private init; }

    public Expression<Func<T, TResult>>? Selector { get; private init; }

    public Expression<Func<T, IEnumerable<TResult>>>? SelectorMany { get; private init; }

    public new Func<IEnumerable<TResult>, IEnumerable<TResult>>? PostProcessingAction { get; private init; }

    public new virtual IEnumerable<TResult> Evaluate(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }
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

    public virtual IEnumerable<T> Evaluate(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public virtual bool IsSatisfiedBy(T entity)
    {
        throw new NotImplementedException();
    }
}
