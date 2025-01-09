using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdAsTrackedSpec :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdAsTrackedSpec(int id) =>
        Query
            .Where(company => company.Id == id)
            .AsTracking();
}
