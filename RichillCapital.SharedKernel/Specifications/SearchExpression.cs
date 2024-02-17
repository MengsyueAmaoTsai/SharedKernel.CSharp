using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications;

public class SearchExpression<T>
{
    private readonly Lazy<Func<T, string>> _selectorFunc;

    public SearchExpression(Expression<Func<T, string>> selector, string searchTerm, int searchGroup = 1)
    {
        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (string.IsNullOrEmpty(searchTerm))
        {
            throw new ArgumentNullException(nameof(searchTerm));
        }

        Selector = selector;
        SearchTerm = searchTerm;
        SearchGroup = searchGroup;

        _selectorFunc = new Lazy<Func<T, string>>(selector.Compile);
    }

    public Expression<Func<T, string>> Selector { get; private init; }

    public string SearchTerm { get; private init; }

    public int SearchGroup { get; private init; }

    public Func<T, string> PredicateFunc => _selectorFunc.Value;
}