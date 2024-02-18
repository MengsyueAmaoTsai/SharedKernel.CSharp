using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class StoreByIdAndNameSpec : Specification<Store>
{
    public StoreByIdAndNameSpec(int id, string name) =>
        Query
            .Where(store => store.Id == id)
            .Where(store => store.Name == name);
}