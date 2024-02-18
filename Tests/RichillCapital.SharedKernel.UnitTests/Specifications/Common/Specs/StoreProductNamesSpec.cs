
using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common;

public sealed class StoreProductNamesSpec : Specification<Store, string?>
{
    public StoreProductNamesSpec() =>
        Query
            .SelectMany(store => store.Products
                .Select(product => product.Name));
}