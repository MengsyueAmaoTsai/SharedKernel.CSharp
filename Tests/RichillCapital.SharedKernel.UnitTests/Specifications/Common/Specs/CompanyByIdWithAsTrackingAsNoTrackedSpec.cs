using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdWithAsTrackingAsNoTrackedSpec :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdWithAsTrackingAsNoTrackedSpec(int id) =>
        Query
            .Where(company => company.Id == id)
            .AsTracking()
            .AsNoTracking();
}
