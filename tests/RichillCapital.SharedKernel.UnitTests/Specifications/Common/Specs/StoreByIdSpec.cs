using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class StoreByIdSpec : Specification<Store>
{
    public StoreByIdSpec(int id) =>
        Query
            .Where(store => store.Id == id);
}