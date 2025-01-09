using System.Linq.Expressions;

using RichillCapital.SharedKernel.Specifications.Exceptions;
using RichillCapital.SharedKernel.Specifications.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Builders;

public static class SpecificationBuilderExtensions
{
    public static ISpecificationBuilder<T> Where<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, bool>> criteria)
        => Where(builder, criteria, true);

    public static ISpecificationBuilder<T> Where<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, bool>> criteria,
        bool condition)
    {
        if (condition)
        {
            builder.Specification.WhereExpressions
                .Add(new WhereExpression<T>(criteria));
        }

        return builder;
    }

    public static IOrderedSpecificationBuilder<T> OrderBy<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, object?>> orderExpression)
        => OrderBy(builder, orderExpression, true);

    public static IOrderedSpecificationBuilder<T> OrderBy<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, object?>> orderExpression,
        bool condition)
    {
        if (condition)
        {
            builder.Specification.OrderExpressions
                .Add(new OrderByExpression<T>(
                    orderExpression,
                    OrderByExpressionType.OrderBy));
        }

        var orderedSpecificationBuilder = new OrderedSpecificationBuilder<T>(
            builder.Specification,
            !condition);

        return orderedSpecificationBuilder;
    }

    public static IOrderedSpecificationBuilder<T> OrderByDescending<T>(
        this ISpecificationBuilder<T> specificationBuilder,
        Expression<Func<T, object?>> orderExpression)
        => OrderByDescending(specificationBuilder, orderExpression, true);

    public static IOrderedSpecificationBuilder<T> OrderByDescending<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, object?>> orderExpression,
        bool condition)
    {
        if (condition)
        {
            builder.Specification.OrderExpressions
                .Add(new OrderByExpression<T>(
                    orderExpression,
                    OrderByExpressionType.OrderByDescending));
        }

        var orderedSpecificationBuilder = new OrderedSpecificationBuilder<T>(
            builder.Specification,
            !condition);

        return orderedSpecificationBuilder;
    }

    public static IIncludeSpecificationBuilder<T, TProperty> Include<T, TProperty>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, TProperty>> includeExpression)
        where T : class
        => Include(builder, includeExpression, true);

    public static IIncludeSpecificationBuilder<T, TProperty> Include<T, TProperty>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, TProperty>> includeExpression,
        bool condition)
        where T : class
    {
        if (condition)
        {
            var info = new IncludeExpression(
                includeExpression,
                typeof(T),
                typeof(TProperty));

            builder.Specification.IncludeExpressions.Add(info);
        }

        var includeBuilder = new IncludeSpecificationBuilder<T, TProperty>(
            builder.Specification,
            !condition);

        return includeBuilder;
    }

    public static ISpecificationBuilder<T> Include<T>(
        this ISpecificationBuilder<T> builder,
        string includeString)
        where T : class
        => Include(builder, includeString, true);

    public static ISpecificationBuilder<T> Include<T>(
        this ISpecificationBuilder<T> builder,
        string includeString,
        bool condition)
        where T : class
    {
        if (condition)
        {
            builder.Specification.IncludeStrings.Add(includeString);
        }

        return builder;
    }

    public static ISpecificationBuilder<T> Search<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, string>> selector,
        string searchTerm,
        int searchGroup = 1)
        where T : class
        => Search(builder, selector, searchTerm, true, searchGroup);

    public static ISpecificationBuilder<T> Search<T>(
        this ISpecificationBuilder<T> builder,
        Expression<Func<T, string>> selector,
        string searchTerm,
        bool condition,
        int searchGroup = 1)
        where T : class
    {
        if (condition)
        {
            builder.Specification.SearchExpressions
                .Add(new SearchExpression<T>(selector, searchTerm, searchGroup));
        }

        return builder;
    }

    public static ISpecificationBuilder<T> Take<T>(
        this ISpecificationBuilder<T> builder,
        int take)
        => Take(builder, take, true);

    public static ISpecificationBuilder<T> Take<T>(
        this ISpecificationBuilder<T> builder,
        int take,
        bool condition)
    {
        if (condition)
        {
            if (builder.Specification.Take is not null)
            {
                throw new DuplicateTakeException();
            }

            builder.Specification.Take = take;
        }

        return builder;
    }

    public static ISpecificationBuilder<T> Skip<T>(
        this ISpecificationBuilder<T> builder,
        int skip)
        => Skip(builder, skip, true);

    public static ISpecificationBuilder<T> Skip<T>(
        this ISpecificationBuilder<T> builder,
        int skip,
        bool condition)
    {
        if (condition)
        {
            if (builder.Specification.Skip is not null)
            {
                throw new DuplicateSkipException();
            }

            builder.Specification.Skip = skip;
        }

        return builder;
    }

    public static ISpecificationBuilder<T, TResult> Select<T, TResult>(
        this ISpecificationBuilder<T, TResult> builder,
        Expression<Func<T, TResult>> selector)
    {
        builder.Specification.Selector = selector;

        return builder;
    }

    public static ISpecificationBuilder<T, TResult> SelectMany<T, TResult>(
        this ISpecificationBuilder<T, TResult> builder,
        Expression<Func<T, IEnumerable<TResult>>> selector)
    {
        builder.Specification.SelectorMany = selector;

        return builder;
    }

    public static ISpecificationBuilder<T> PostProcessingAction<T>(
        this ISpecificationBuilder<T> builder,
        Func<IEnumerable<T>, IEnumerable<T>> predicate)
    {
        builder.Specification.PostProcessingAction = predicate;

        return builder;
    }

    public static ISpecificationBuilder<T, TResult> PostProcessingAction<T, TResult>(
        this ISpecificationBuilder<T, TResult> builder,
        Func<IEnumerable<TResult>, IEnumerable<TResult>> predicate)
    {
        builder.Specification.PostProcessingAction = predicate;

        return builder;
    }

    public static ISpecificationBuilder<T> AsTracking<T>(
        this ISpecificationBuilder<T> builder)
        where T : class
        => AsTracking(builder, true);

    public static ISpecificationBuilder<T> AsTracking<T>(
        this ISpecificationBuilder<T> builder,
        bool condition)
        where T : class
    {
        if (condition)
        {
            builder.Specification.AsNoTracking = false;
            builder.Specification.AsNoTrackingWithIdentityResolution = false;
            builder.Specification.AsTracking = true;
        }

        return builder;
    }

    public static ISpecificationBuilder<T> AsNoTracking<T>(
        this ISpecificationBuilder<T> builder)
        where T : class
        => AsNoTracking(builder, true);

    public static ISpecificationBuilder<T> AsNoTracking<T>(
        this ISpecificationBuilder<T> builder,
        bool condition)
        where T : class
    {
        if (condition)
        {
            builder.Specification.AsTracking = false;
            builder.Specification.AsNoTrackingWithIdentityResolution = false;
            builder.Specification.AsNoTracking = true;
        }

        return builder;
    }

    public static ISpecificationBuilder<T> AsSplitQuery<T>(
        this ISpecificationBuilder<T> builder)
        where T : class
        => AsSplitQuery(builder, true);

    public static ISpecificationBuilder<T> AsSplitQuery<T>(
        this ISpecificationBuilder<T> builder,
        bool condition)
        where T : class
    {
        if (condition)
        {
            builder.Specification.AsSplitQuery = true;
        }

        return builder;
    }

    public static ISpecificationBuilder<T> AsNoTrackingWithIdentityResolution<T>(
        this ISpecificationBuilder<T> builder)
        where T : class
        => AsNoTrackingWithIdentityResolution(builder, true);

    public static ISpecificationBuilder<T> AsNoTrackingWithIdentityResolution<T>(
        this ISpecificationBuilder<T> builder,
        bool condition)
        where T : class
    {
        if (condition)
        {
            builder.Specification.AsTracking = false;
            builder.Specification.AsNoTracking = false;
            builder.Specification.AsNoTrackingWithIdentityResolution = true;
        }

        return builder;
    }

    public static ISpecificationBuilder<T> IgnoreQueryFilters<T>(
        this ISpecificationBuilder<T> builder)
        where T : class
        => IgnoreQueryFilters(builder, true);

    public static ISpecificationBuilder<T> IgnoreQueryFilters<T>(
        this ISpecificationBuilder<T> builder,
        bool condition)
        where T : class
    {
        if (condition)
        {
            builder.Specification.IgnoreQueryFilters = true;
        }

        return builder;
    }
}