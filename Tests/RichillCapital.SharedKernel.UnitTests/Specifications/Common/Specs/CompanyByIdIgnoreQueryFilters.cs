using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdIgnoreQueryFilters :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdIgnoreQueryFilters(int id) =>
        Query
            .Where(company => company.Id == id)
            .IgnoreQueryFilters();
}
