using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications;

public sealed class IncludeExpression
{
    public LambdaExpression LambdaExpression { get; private init; }

    public Type EntityType { get; private init; }

    public Type PropertyType { get; private init; }

    public Type? PreviousPropertyType { get; private init; }

    public IncludeType Type { get; private init; }

    private IncludeExpression(
        LambdaExpression expression,
        Type entityType,
        Type propertyType,
        Type? previousPropertyType,
        IncludeType includeType)
    {
        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        if (entityType is null)
        {
            throw new ArgumentNullException(nameof(entityType));
        }

        if (propertyType is null)
        {
            throw new ArgumentNullException(nameof(propertyType));
        }

        if (includeType == IncludeType.ThenInclude)
        {
            if (previousPropertyType is null)
            {
                throw new ArgumentNullException(nameof(previousPropertyType));
            }
        }

        LambdaExpression = expression;
        EntityType = entityType;
        PropertyType = propertyType;
        PreviousPropertyType = previousPropertyType;
        Type = includeType;
    }

    public IncludeExpression(
        Expression<Func<object, object>> expression,
        Type entityType,
        Type propertyType,
        IncludeType includeType)
        : this(expression, entityType, propertyType, null, includeType)
    {
    }

    public IncludeExpression(
        Expression<Func<object, object>> expression,
        Type entityType,
        Type propertyType,
        Type previousPropertyType)
        : this(expression, entityType, propertyType, previousPropertyType, IncludeType.ThenInclude)
    {
    }
}

public enum IncludeType
{
    Include = 1,

    ThenInclude = 2,
}