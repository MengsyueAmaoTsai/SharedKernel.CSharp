using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreIncludeCompanyThenCountryAsStringSpec : Specification<Store>
{
    public StoreIncludeCompanyThenCountryAsStringSpec() =>
        Query.Include($"{nameof(Company)}.{nameof(Company.Country)}");
}
