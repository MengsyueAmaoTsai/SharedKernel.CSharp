using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoresOrderedSpecByName : Specification<Store>
{
    public StoresOrderedSpecByName() =>
        Query.OrderBy(store => store.Name);
}
