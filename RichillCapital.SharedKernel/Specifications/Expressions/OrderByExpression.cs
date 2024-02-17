namespace RichillCapital.SharedKernel.Specifications.Expressions;

using System.Linq.Expressions;

public class OrderByExpression<T>
{
    private readonly Lazy<Func<T, object?>> _keySelectorFunc;

    public OrderByExpression(
        Expression<Func<T, object?>> keySelector,
        OrderByExpressionType orderByExpressionType)
    {
        if (keySelector is null)
        {
            throw new ArgumentNullException(nameof(keySelector));
        }

        KeySelector = keySelector;
        OrderType = orderByExpressionType;

        _keySelectorFunc = new Lazy<Func<T, object?>>(KeySelector.Compile);
    }

    public Expression<Func<T, object?>> KeySelector { get; }

    public OrderByExpressionType OrderType { get; }

    public Func<T, object?> KeySelectorFunc => _keySelectorFunc.Value;
}