using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class CompanyByIdAsSplitQuery :
    Specification<Company>,
    ISingleResultSpecification<Company>
{
    public CompanyByIdAsSplitQuery(int id) =>
        Query
            .Where(company => company.Id == id)
            .Include(x => x.Stores)
            .ThenInclude(x => x.Products)
            .AsSplitQuery();
}
