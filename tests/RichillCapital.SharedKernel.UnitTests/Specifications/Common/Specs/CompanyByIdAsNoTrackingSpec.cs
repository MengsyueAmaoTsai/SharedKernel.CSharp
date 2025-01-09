using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public class CompanyByIdAsNoTrackingSpec :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdAsNoTrackingSpec(int id) =>
        Query
            .Where(company => company.Id == id)
            .AsNoTracking();
}
