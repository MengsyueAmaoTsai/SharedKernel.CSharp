using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoresByCompanyOrderedDescByNameThenByIdSpec : Specification<Store>
{
    public StoresByCompanyOrderedDescByNameThenByIdSpec(int companyId) =>
        Query
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.Name)
            .ThenBy(x => x.Id);
}
