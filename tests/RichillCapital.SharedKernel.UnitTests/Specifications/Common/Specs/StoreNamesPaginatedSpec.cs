using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class StoreNamesPaginatedSpec :
    Specification<Store, string?>
{
    public StoreNamesPaginatedSpec(int skip, int take)
    {
        Query
            .OrderBy(store => store.Id)
            .Skip(skip)
            .Take(take);

        Query.Select(store => store.Name);
    }
}