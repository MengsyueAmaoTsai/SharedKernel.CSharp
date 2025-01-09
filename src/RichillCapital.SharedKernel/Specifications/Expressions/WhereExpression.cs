using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Expressions;

public class WhereExpression<T>
{
    private readonly Lazy<Func<T, bool>> _filterFunc;

    public WhereExpression(Expression<Func<T, bool>> filter)
    {
        if (filter is null)
        {
            throw new ArgumentNullException(nameof(filter));
        }

        Filter = filter;

        _filterFunc = new Lazy<Func<T, bool>>(Filter.Compile);
    }

    public Expression<Func<T, bool>> Filter { get; }

    public Func<T, bool> FilterFunc => _filterFunc.Value;
}