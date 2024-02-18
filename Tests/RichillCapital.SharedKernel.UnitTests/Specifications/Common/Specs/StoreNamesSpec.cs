using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreNamesSpec : Specification<Store, string?>
{
    public StoreNamesSpec() =>
        Query.Select(store => store.Name);
}
