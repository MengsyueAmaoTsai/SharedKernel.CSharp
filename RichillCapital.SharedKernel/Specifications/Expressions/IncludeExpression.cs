namespace RichillCapital.SharedKernel.Specifications.Expressions;

using System.Linq.Expressions;

public class IncludeExpression
{
    public IncludeExpression(
        LambdaExpression expression,
        Type entityType,
        Type propertyType)
        : this(expression, entityType, propertyType, null, IncludeExpressionType.Include)
    {
    }

    public IncludeExpression(
        LambdaExpression expression,
        Type entityType,
        Type propertyType,
        Type previousPropertyType)
        : this(
            expression, entityType, propertyType, previousPropertyType, IncludeExpressionType.ThenInclude)
    {
    }

    private IncludeExpression(
         LambdaExpression expression,
         Type entityType,
         Type propertyType,
         Type? previousPropertyType,
         IncludeExpressionType includeType)
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

        if (includeType == IncludeExpressionType.ThenInclude)
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

    public LambdaExpression LambdaExpression { get; }

    public Type EntityType { get; }

    public Type PropertyType { get; }

    public Type? PreviousPropertyType { get; }

    public IncludeExpressionType Type { get; }
}