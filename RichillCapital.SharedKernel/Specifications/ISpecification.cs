using System.Linq.Expressions;

using RichillCapital.SharedKernel.Specifications.Builders;
using RichillCapital.SharedKernel.Specifications.Expressions;

namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecification<T, TResult> : ISpecification<T>
{
    new ISpecificationBuilder<T, TResult> Query { get; }

    Expression<Func<T, TResult>>? Selector { get; }

    Expression<Func<T, IEnumerable<TResult>>>? SelectorMany { get; }

    new Func<IEnumerable<TResult>, IEnumerable<TResult>>? PostProcessingAction { get; }

    new IEnumerable<TResult> Evaluate(IEnumerable<T> entities);
}

public interface ISpecification<T>
{
    ISpecificationBuilder<T> Query { get; }

    IDictionary<string, object> Items { get; }

    IEnumerable<WhereExpression<T>> WhereExpressions { get; }

    IEnumerable<OrderByExpression<T>> OrderExpressions { get; }

    IEnumerable<IncludeExpression> IncludeExpressions { get; }

    IEnumerable<string> IncludeStrings { get; }

    IEnumerable<SearchExpression<T>> SearchExpressions { get; }

    int? Take { get; }

    int? Skip { get; }

    Func<IEnumerable<T>, IEnumerable<T>>? PostProcessingAction { get; }

    bool CacheEnabled { get; }

    string? CacheKey { get; }

    bool AsTracking { get; }

    bool AsNoTracking { get; }

    bool AsSplitQuery { get; }

    bool AsNoTrackingWithIdentityResolution { get; }

    bool IgnoreQueryFilters { get; }

    IEnumerable<T> Evaluate(IEnumerable<T> entities);

    bool IsSatisfiedBy(T entity);
}