using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdWithAsTrackingAsUntrackedWithIdentityResolutionSpec :
    Specification<Company>,
  ISingleResultSpecification<Company>
{
  public CompanyByIdWithAsTrackingAsUntrackedWithIdentityResolutionSpec(int id) =>
      Query
          .Where(company => company.Id == id)
          .AsTracking()
          .AsNoTrackingWithIdentityResolution();
}
