using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Expressions;

public class WhereExpression<T>
{
    private readonly Lazy<Func<T, bool>> _predicateFunc;

    public WhereExpression(Expression<Func<T, bool>> predicate)
    {
        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        Predicate = predicate;
        _predicateFunc = new Lazy<Func<T, bool>>(predicate.Compile);
    }

    public Expression<Func<T, bool>> Predicate { get; private init; }

    public Func<T, bool> PredicateFunc => _predicateFunc.Value;
}