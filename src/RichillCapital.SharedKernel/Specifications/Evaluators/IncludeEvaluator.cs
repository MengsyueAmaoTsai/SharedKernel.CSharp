using System.Linq.Expressions;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using RichillCapital.SharedKernel.Specifications.Expressions;

using IncludeExpression = RichillCapital.SharedKernel.Specifications.Expressions.IncludeExpression;

namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public class IncludeEvaluator : IEvaluator
{
    private static readonly MethodInfo _includeMethodInfo =
        typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.Include))
            .Single(
                info => info.GetGenericArguments().Length == 2 &&
                info.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>) &&
                info.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>));

    private static readonly MethodInfo _thenIncludeAfterReferenceMethodInfo =
        typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.ThenInclude))
            .Single(
                info => info.GetGenericArguments().Length == 3 &&
                info.GetParameters()[0].ParameterType.GenericTypeArguments[1].IsGenericParameter &&
                info
                    .GetParameters()[0]
                    .ParameterType.GetGenericTypeDefinition() == typeof(IIncludableQueryable<,>) &&
                info
                    .GetParameters()[1]
                    .ParameterType.GetGenericTypeDefinition() == typeof(Expression<>));

    private static readonly MethodInfo _thenIncludeAfterEnumerableMethodInfo =
        typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.ThenInclude))
            .Where(info => info.GetGenericArguments().Length == 3)
            .Single(info =>
            {
                var typeInfo = info.GetParameters()[0].ParameterType.GenericTypeArguments[1];

                return typeInfo.IsGenericType &&
                    typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                    info
                        .GetParameters()[0]
                        .ParameterType.GetGenericTypeDefinition() == typeof(IIncludableQueryable<,>) &&
                    info
                        .GetParameters()[1]
                        .ParameterType.GetGenericTypeDefinition() == typeof(Expression<>);
            });

    public static IncludeEvaluator Default { get; } = new IncludeEvaluator();

    public bool IsCriteriaEvaluator => false;

    public IQueryable<T> GetQuery<T>(
        IQueryable<T> query,
        ISpecification<T> specification)
        where T : class
    {
        foreach (var includeString in specification.IncludeStrings)
        {
            query = query.Include(includeString);
        }

        foreach (var includeInfo in specification.IncludeExpressions)
        {
            if (includeInfo.Type == IncludeExpressionType.Include)
            {
                query = BuildInclude<T>(query, includeInfo);
            }
            else if (includeInfo.Type == IncludeExpressionType.ThenInclude)
            {
                query = BuildThenInclude<T>(query, includeInfo);
            }
        }

        return query;
    }

    private static Lazy<Func<IQueryable, LambdaExpression, IQueryable>> CreateIncludeDelegate((
        Type EntityType,
        Type PropertyType,
        Type? PreviousPropertyType) cacheKey) =>
        new(() =>
        {
            var concreteInclude = _includeMethodInfo
                .MakeGenericMethod(cacheKey.EntityType, cacheKey.PropertyType);
            var sourceParameter = Expression.Parameter(typeof(IQueryable));
            var selectorParameter = Expression.Parameter(typeof(LambdaExpression));

            var call = Expression.Call(
                  concreteInclude,
                  Expression.Convert(
                    sourceParameter,
                    typeof(IQueryable<>)
                        .MakeGenericType(cacheKey.EntityType)),
                  Expression.Convert(
                    selectorParameter,
                    typeof(Expression<>)
                        .MakeGenericType(typeof(Func<,>)
                        .MakeGenericType(cacheKey.EntityType, cacheKey.PropertyType))));

            var lambda = Expression
                .Lambda<Func<IQueryable, LambdaExpression, IQueryable>>(
                    call,
                    sourceParameter,
                    selectorParameter);

            return lambda.Compile();
        });

    private static Lazy<Func<IQueryable, LambdaExpression, IQueryable>> CreateThenIncludeDelegate((
        Type EntityType,
        Type PropertyType,
        Type? PreviousPropertyType) cacheKey) => new(() =>
        {
            var thenIncludeInfo = _thenIncludeAfterReferenceMethodInfo;

            if (IsGenericEnumerable(cacheKey.PreviousPropertyType, out var previousPropertyType))
            {
                thenIncludeInfo = _thenIncludeAfterEnumerableMethodInfo;
            }

            var concreteThenInclude = thenIncludeInfo
                .MakeGenericMethod(
                    cacheKey.EntityType,
                    previousPropertyType,
                    cacheKey.PropertyType);
            var sourceParameter = Expression.Parameter(typeof(IQueryable));
            var selectorParameter = Expression.Parameter(typeof(LambdaExpression));

            var call = Expression.Call(
                  concreteThenInclude,
                  Expression.Convert(
                      sourceParameter,
                      typeof(IIncludableQueryable<,>)
                        .MakeGenericType(
                            cacheKey.EntityType,
                            cacheKey.PreviousPropertyType)),
                  Expression.Convert(
                    selectorParameter,
                    typeof(Expression<>)
                        .MakeGenericType(typeof(Func<,>)
                        .MakeGenericType(previousPropertyType, cacheKey.PropertyType))));

            var lambda = Expression
                .Lambda<Func<IQueryable, LambdaExpression, IQueryable>>(
                    call,
                    sourceParameter,
                    selectorParameter);

            return lambda.Compile();
        });

    private static bool IsGenericEnumerable(Type type, out Type propertyType)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            propertyType = type.GenericTypeArguments[0];

            return true;
        }

        propertyType = type;

        return false;
    }

    private IQueryable<T> BuildInclude<T>(IQueryable query, IncludeExpression include)
    {
        if (include is null)
        {
            throw new ArgumentNullException(nameof(include));
        }

        var result = _includeMethodInfo
            .MakeGenericMethod(include.EntityType, include.PropertyType)
            .Invoke(null, [query, include.LambdaExpression]) ??
            throw new TargetException();

        return (IQueryable<T>)result;
    }

    private IQueryable<T> BuildThenInclude<T>(IQueryable query, IncludeExpression includeInfo)
    {
        if (includeInfo is null)
        {
            throw new ArgumentNullException(nameof(includeInfo));
        }

        if (includeInfo.PreviousPropertyType is null)
        {
            throw new ArgumentNullException(nameof(includeInfo.PreviousPropertyType));
        }

        var result = (IsGenericEnumerable(includeInfo.PreviousPropertyType, out var previousPropertyType) ?
            _thenIncludeAfterEnumerableMethodInfo :
            _thenIncludeAfterReferenceMethodInfo)
                .MakeGenericMethod(
                    includeInfo.EntityType,
                    previousPropertyType,
                    includeInfo.PropertyType)
                .Invoke(null, [query, includeInfo.LambdaExpression,]) ??
                throw new TargetException();

        return (IQueryable<T>)result;
    }
}
