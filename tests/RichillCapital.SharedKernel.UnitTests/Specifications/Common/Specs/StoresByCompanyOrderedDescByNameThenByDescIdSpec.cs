using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoresByCompanyOrderedDescByNameThenByDescIdSpec : Specification<Store>
{
    public StoresByCompanyOrderedDescByNameThenByDescIdSpec(int companyId) =>
        Query
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.Name)
            .ThenByDescending(x => x.Id);
}
