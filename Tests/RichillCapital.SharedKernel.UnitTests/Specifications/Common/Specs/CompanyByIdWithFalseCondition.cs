using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class CompanyByIdWithFalseConditions : Specification<Company>
{
    public CompanyByIdWithFalseConditions(int id) =>
        Query
            .Where(company => company.Id == id, false)
            .OrderBy(company => company.Id, false)
                .ThenBy(company => company.Name)
                .ThenByDescending(company => company.Name)
            .OrderByDescending(company => company.Id, false)
                .ThenBy(company => company.Name)
                .ThenByDescending(company => company.Name)
            .Include(company => company.Stores, false)
            .Take(10, false)
            .Skip(10, false)
            .AsNoTracking(false)
            .AsNoTrackingWithIdentityResolution(false)
            .AsSplitQuery(false)
            .IgnoreQueryFilters(false)
            .Search(company => company.Name!, "test", false);
}