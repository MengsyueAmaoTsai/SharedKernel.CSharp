using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdAsUntrackedWithIdentityResolutionSpec :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdAsUntrackedWithIdentityResolutionSpec(int id) =>
        Query
            .Where(company => company.Id == id)
            .AsNoTrackingWithIdentityResolution();
}
