using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreIncludeCompanyThenCountrySpec :
    Specification<Store>
{
    public StoreIncludeCompanyThenCountrySpec() =>
        Query
            .Include(store => store.Company)
             .ThenInclude(company => company!.Country);
}
