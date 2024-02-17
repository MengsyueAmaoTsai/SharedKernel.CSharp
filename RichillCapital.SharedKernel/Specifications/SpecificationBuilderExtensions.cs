using System.Linq.Expressions;

using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.Specifications;

public static class SpecificationBuilderExtensions
{
    public static SpecificationBuilder<T> Where<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, bool>> whereExpression) =>
        Where(builder, whereExpression, true);

    public static SpecificationBuilder<T> Where<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, bool>> whereExpression,
        bool condition)
    {
        if (condition)
        {
            ((List<Expression<Func<T, bool>>>)builder.Specification.WhereExpressions).Add(whereExpression);
        }

        return builder;
    }

    public static SpecificationBuilder<T> OrderBy<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, object>> orderExpression) =>
        OrderBy(builder, orderExpression, true);

    public static SpecificationBuilder<T> OrderBy<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, object>> orderExpression,
        bool condition)
    {
        if (condition)
        {
            ((List<Expression<Func<T, object>>>)builder.Specification.OrderByExpressions).Add(orderExpression);
        }

        return builder;
    }

    public static SpecificationBuilder<T> OrderByDescending<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, object>> orderExpression) =>
        OrderByDescending(builder, orderExpression, true);

    public static SpecificationBuilder<T> OrderByDescending<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, object>> orderExpression,
        bool condition)
    {
        if (condition)
        {
            ((List<Expression<Func<T, object>>>)builder.Specification.OrderByExpressions).Add(orderExpression);
        }

        return builder;
    }

    public static SpecificationBuilder<T, TProperty> Include<T, TProperty>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, TProperty>> includeExpression)
        where T : class =>
        Include(builder, includeExpression, true);

    public static SpecificationBuilder<T, TProperty> Include<T, TProperty>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, TProperty>> includeExpression,
        bool condition)
        where T : class
    {
        // if (condition)
        // {
        //     ((List<Expression<Func<T, object>>>)builder.Specification.IncludeExpressions).Add(includeExpression);
        // }

        // return builder;
        throw new NotImplementedException();
    }

    public static SpecificationBuilder<T> Include<T>(this SpecificationBuilder<T> builder, string includeString)
        where T : class =>
        Include(builder, includeString, true);

    public static SpecificationBuilder<T> Include<T>(
        this SpecificationBuilder<T> builder,
        string includeString,
        bool condition)
        where T : class
    {
        if (condition)
        {
            // ((List<Expression<Func<T, object>>>)builder.Specification.IncludeExpressions).Add(includeExpression);
        }

        return builder;
    }

    public static SpecificationBuilder<T> Search<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, string>> selector,
        string searchTerm,
        int searchGroup = 1)
        where T : class =>
        Search(builder, selector, searchTerm, true, searchGroup);

    public static SpecificationBuilder<T> Search<T>(
        this SpecificationBuilder<T> builder,
        Expression<Func<T, string>> selector,
        string searchTerm,
        bool condition,
        int searchGroup = 1)
        where T : class
    {
        if (condition)
        {
        }

        return builder;
    }

    public static SpecificationBuilder<T> Take<T>(
        this SpecificationBuilder<T> builder,
        int take) =>
        Take(builder, take, true);

    public static SpecificationBuilder<T> Take<T>(
        this SpecificationBuilder<T> builder,
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

    public static SpecificationBuilder<T> Skip<T>(
        this SpecificationBuilder<T> builder,
        int skip) => Skip(builder, skip, true);

    public static SpecificationBuilder<T> Skip<T>(
        this SpecificationBuilder<T> builder,
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

    // public static SpecificationBuilder<T, TResult> Select<T, TResult>(
    //     this SpecificationBuilder<T, TResult> builder,
    //     Expression<Func<T, TResult>> selector)
    // {
    //     builder.Specification.Selector = selector;

    //     return builder;
    // }

    // public static SpecificationBuilder<T, TResult> SelectMany<T, TResult>(
    //     this SpecificationBuilder<T, TResult> builder,
    //     Expression<Func<T, IEnumerable<TResult>>> selector)
    // {
    //     builder.Specification.SelectMany = selector;

    //     return builder;
    // }

    public static SpecificationBuilder<T> AsTracking<T>(
        this SpecificationBuilder<T> builder)
        where T : class => AsTracking(builder, true);

    public static SpecificationBuilder<T> AsTracking<T>(
        this SpecificationBuilder<T> builder,
        bool asTracking)
        where T : class
    {
        if (asTracking)
        {
            builder.Specification.AsTracking = true;
            builder.Specification.AsNoTracking = false;
            builder.Specification.AsNoTrackingWithIdentityResolution = false;
        }

        return builder;
    }

    public static SpecificationBuilder<T> AsNoTracking<T>(
        this SpecificationBuilder<T> builder)
        where T : class => AsNoTracking(builder, true);

    public static SpecificationBuilder<T> AsNoTracking<T>(
        this SpecificationBuilder<T> builder,
        bool asNoTracking)
        where T : class
    {
        if (asNoTracking)
        {
            builder.Specification.AsTracking = false;
            builder.Specification.AsNoTracking = true;
            builder.Specification.AsNoTrackingWithIdentityResolution = false;
        }

        return builder;
    }

    public static SpecificationBuilder<T> AsSplitQuery<T>(
        this SpecificationBuilder<T> builder)
        where T : class => AsSplitQuery(builder, true);

    public static SpecificationBuilder<T> AsSplitQuery<T>(
        this SpecificationBuilder<T> builder,
        bool asSplitQuery)
        where T : class
    {
        if (asSplitQuery)
        {
            builder.Specification.AsSplitQuery = true;
        }

        return builder;
    }

    public static SpecificationBuilder<T> AsNoTrackingWithIdentityResolution<T>(
        this SpecificationBuilder<T> builder)
        where T : class => AsNoTrackingWithIdentityResolution(builder, true);

    public static SpecificationBuilder<T> AsNoTrackingWithIdentityResolution<T>(
        this SpecificationBuilder<T> builder,
        bool asNoTrackingWithIdentityResolution)
        where T : class
    {
        if (asNoTrackingWithIdentityResolution)
        {
            builder.Specification.AsTracking = false;
            builder.Specification.AsNoTracking = false;
            builder.Specification.AsNoTrackingWithIdentityResolution = true;
        }

        return builder;
    }

    public static SpecificationBuilder<T> IgnoreQueryFilters<T>(
        this SpecificationBuilder<T> builder)
        where T : class => IgnoreQueryFilters(builder, true);

    public static SpecificationBuilder<T> IgnoreQueryFilters<T>(
        this SpecificationBuilder<T> builder,
        bool ignoreQueryFilters)
        where T : class
    {
        if (ignoreQueryFilters)
        {
            builder.Specification.IgnoreQueryFilters = true;
        }

        return builder;
    }
}
