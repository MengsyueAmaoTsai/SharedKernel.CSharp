using System.Linq.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Expressions;

public class SearchExpression<T>
{
    private readonly Lazy<Func<T, string>> _selectorFunc;

    public SearchExpression(
        Expression<Func<T, string>> selector,
        string searchTerm,
        int searchGroup = 1)
    {
        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (string.IsNullOrEmpty(searchTerm))
        {
            throw new ArgumentException("The search term can not be null or empty.");
        }

        Selector = selector;
        SearchTerm = searchTerm;
        SearchGroup = searchGroup;

        _selectorFunc = new Lazy<Func<T, string>>(Selector.Compile);
    }

    public Expression<Func<T, string>> Selector { get; }

    public string SearchTerm { get; }

    public int SearchGroup { get; }

    public Func<T, string> SelectorFunc => _selectorFunc.Value;
}