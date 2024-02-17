using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Expressions;

public sealed class OrderByExpression<T>
{
    private readonly Lazy<Func<T, object?>> _keySelectorFunc;

    public OrderByExpression(
        Expression<Func<T, object?>>
        keySelector,
        OrderByType orderByType)
    {
        if (keySelector is null)
        {
            throw new ArgumentNullException(nameof(keySelector));
        }

        KeySelector = keySelector;
        OrderByType = orderByType;
        _keySelectorFunc = new Lazy<Func<T, object?>>(keySelector.Compile);
    }

    public Expression<Func<T, object?>> KeySelector { get; private init; }

    public OrderByType OrderByType { get; private init; }

    public Func<T, object?> KeySelectorFunc => _keySelectorFunc.Value;
}

public enum OrderByType
{
    OrderBy = 1,
    OrderByDescending = 2,
    ThenBy = 3,
    ThenByDescending = 4,
}