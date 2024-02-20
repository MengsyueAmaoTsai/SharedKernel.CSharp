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

    List<WhereExpression<T>> WhereExpressions { get; }

    List<OrderByExpression<T>> OrderExpressions { get; }

    List<IncludeExpression> IncludeExpressions { get; }

    List<string> IncludeStrings { get; }

    List<SearchExpression<T>> SearchExpressions { get; }

    int? Take { get; }

    int? Skip { get; }

    Func<IEnumerable<T>, IEnumerable<T>>? PostProcessingAction { get; }

    bool AsTracking { get; }

    bool AsNoTracking { get; }

    bool AsSplitQuery { get; }

    bool AsNoTrackingWithIdentityResolution { get; }

    bool IgnoreQueryFilters { get; }

    IEnumerable<T> Evaluate(IEnumerable<T> entities);

    bool IsSatisfiedBy(T entity);
}