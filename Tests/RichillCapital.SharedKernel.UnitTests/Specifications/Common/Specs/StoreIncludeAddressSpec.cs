using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreIncludeAddressSpec : Specification<Store>
{
    public StoreIncludeAddressSpec() =>
        Query.Include(store => store.Address);
}
