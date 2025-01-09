using System.Linq.Expressions;

using RichillCapital.SharedKernel.Specifications.Builders;
using RichillCapital.SharedKernel.Specifications.Evaluators;
using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.Specifications.Validators;

namespace RichillCapital.SharedKernel.Specifications;

public abstract class Specification<T, TResult> :
    Specification<T>,
    ISpecification<T, TResult>
{
    protected Specification()
        : this(InMemorySpecificationEvaluator.Default)
    {
    }

    protected Specification(IInMemorySpecificationEvaluator inMemorySpecificationEvaluator)
        : base(inMemorySpecificationEvaluator) =>
        Query = new SpecificationBuilder<T, TResult>(this);

    public new virtual ISpecificationBuilder<T, TResult> Query { get; }

    public Expression<Func<T, TResult>>? Selector { get; internal set; }

    public Expression<Func<T, IEnumerable<TResult>>>? SelectorMany { get; internal set; }

    public new Func<IEnumerable<TResult>, IEnumerable<TResult>>? PostProcessingAction { get; internal set; } = null;

    public new virtual IEnumerable<TResult> Evaluate(IEnumerable<T> entities)
    {
        return Evaluator.Evaluate(entities, this);
    }
}

public abstract class Specification<T> : ISpecification<T>
{
    protected Specification()
        : this(InMemorySpecificationEvaluator.Default, SpecificationValidator.Default)
    {
    }

    protected Specification(IInMemorySpecificationEvaluator inMemorySpecificationEvaluator)
        : this(inMemorySpecificationEvaluator, SpecificationValidator.Default)
    {
    }

    protected Specification(ISpecificationValidator specificationValidator)
        : this(InMemorySpecificationEvaluator.Default, specificationValidator)
    {
    }

    protected Specification(
        IInMemorySpecificationEvaluator inMemorySpecificationEvaluator,
        ISpecificationValidator specificationValidator) =>
        (Evaluator, Validator, Query) = (
            inMemorySpecificationEvaluator,
            specificationValidator,
            new SpecificationBuilder<T>(this));

    public virtual ISpecificationBuilder<T> Query { get; }

    public IDictionary<string, object> Items { get; set; } = new Dictionary<string, object>();

    public List<WhereExpression<T>> WhereExpressions { get; } = [];

    public List<OrderByExpression<T>> OrderExpressions { get; } = [];

    public List<IncludeExpression> IncludeExpressions { get; } = [];

    public List<string> IncludeStrings { get; } = [];

    public List<SearchExpression<T>> SearchExpressions { get; } = [];

    public int? Take { get; internal set; } = null;

    public int? Skip { get; internal set; } = null;

    public Func<IEnumerable<T>, IEnumerable<T>>? PostProcessingAction { get; internal set; } = null;

    public bool AsTracking { get; internal set; } = false;

    public bool AsNoTracking { get; internal set; } = false;

    public bool AsSplitQuery { get; internal set; } = false;

    public bool AsNoTrackingWithIdentityResolution { get; internal set; } = false;

    public bool IgnoreQueryFilters { get; internal set; } = false;

    protected IInMemorySpecificationEvaluator Evaluator { get; private init; }

    protected ISpecificationValidator Validator { get; private init; }

    public virtual IEnumerable<T> Evaluate(IEnumerable<T> entities) =>
        Evaluator.Evaluate(entities, this);

    public virtual bool IsSatisfiedBy(T entity) => Validator.IsValid(entity, this);
}