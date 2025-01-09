using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoresOrderedDescendingByNameSpec : Specification<Store>
{
    public StoresOrderedDescendingByNameSpec() =>
        Query.OrderByDescending(store => store.Name);
}
