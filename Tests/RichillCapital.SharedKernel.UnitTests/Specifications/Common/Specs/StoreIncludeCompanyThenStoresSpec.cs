using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreIncludeCompanyThenStoresSpec : Specification<Store>
{
    public StoreIncludeCompanyThenStoresSpec() =>
        Query
            .Include(x => x.Company)
            .ThenInclude(x => x!.Stores)
            .ThenInclude(x => x.Products);
}
