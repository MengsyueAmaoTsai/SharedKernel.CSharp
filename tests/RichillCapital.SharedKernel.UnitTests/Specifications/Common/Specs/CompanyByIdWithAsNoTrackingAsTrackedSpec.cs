using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdWithAsNoTrackingAsTrackedSpec :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdWithAsNoTrackingAsTrackedSpec(int id) =>
        Query
            .Where(company => company.Id == id)
            .AsNoTracking()
            .AsNoTrackingWithIdentityResolution()
            .AsTracking();
}
