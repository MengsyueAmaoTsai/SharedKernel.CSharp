using System.Linq.Expressions;

using RichillCapital.SharedKernel.Specifications.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Builders;

public static class IncludeSpecificationBuilderExtensions
{
    public static IIncludeSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludeSpecificationBuilder<TEntity, TPreviousProperty> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression)
        where TEntity : class
        => ThenInclude(previousBuilder, thenIncludeExpression, true);

    public static IIncludeSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludeSpecificationBuilder<TEntity, TPreviousProperty> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression,
        bool condition)
        where TEntity : class
    {
        if (condition && !previousBuilder.IsChainDiscarded)
        {
            var info = new IncludeExpression(
                thenIncludeExpression,
                typeof(TEntity),
                typeof(TProperty),
                typeof(TPreviousProperty));

            previousBuilder.Specification.IncludeExpressions.Add(info);
        }

        var includeBuilder = new IncludeSpecificationBuilder<TEntity, TProperty>(
            previousBuilder.Specification,
            !condition || previousBuilder.IsChainDiscarded);

        return includeBuilder;
    }

    public static IIncludeSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludeSpecificationBuilder<TEntity, IEnumerable<TPreviousProperty>> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression)
        where TEntity : class
        => ThenInclude(previousBuilder, thenIncludeExpression, true);

    public static IIncludeSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludeSpecificationBuilder<TEntity, IEnumerable<TPreviousProperty>> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression,
        bool condition)
        where TEntity : class
    {
        if (condition && !previousBuilder.IsChainDiscarded)
        {
            var info = new IncludeExpression(
                thenIncludeExpression,
                typeof(TEntity),
                typeof(TProperty),
                typeof(IEnumerable<TPreviousProperty>));

            previousBuilder.Specification.IncludeExpressions.Add(info);
        }

        var includeBuilder = new IncludeSpecificationBuilder<TEntity, TProperty>(
            previousBuilder.Specification,
            !condition || previousBuilder.IsChainDiscarded);

        return includeBuilder;
    }
}