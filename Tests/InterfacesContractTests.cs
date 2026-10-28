using Interfaces;

namespace Tests;

public class InterfacesContractTests
{
    private sealed class FakeProducer : IProducer
    {
        public string Name { get; init; } = "Arasaka";
        public string HeadQuarters { get; init; } = "Tokio";
        public int Employees { get; init; } = 1_000_000;
    }

    private sealed class FakeProduct : IProduct
    {
        public string Name { get; init; } = "Neural Processor";
        public ImplantType Type { get; init; } = ImplantType.NeuralProcessor;
        public decimal Price { get; init; } = 20_000m;
        public string ProducerName { get; init; } = "Arasaka";
    }

    private sealed class FakeDao : IDAO
    {
        public IEnumerable<IProducer> GetAllProducers() => [new FakeProducer()];
        public IEnumerable<IProduct> GetAllProducts() => [new FakeProduct()];
    }

    [Fact]
    public void IDao_returns_interface_typed_enumerables()
    {
        IDAO dao = new FakeDao();

        Assert.IsAssignableFrom<IEnumerable<IProducer>>(dao.GetAllProducers());
        Assert.IsAssignableFrom<IEnumerable<IProduct>>(dao.GetAllProducts());
    }

    [Fact]
    public void ImplantType_contains_the_cyberware_categories()
    {
        var names = Enum.GetNames<ImplantType>();

        Assert.Contains(nameof(ImplantType.NeuralProcessor), names);
        Assert.Contains(nameof(ImplantType.Cyberoptics), names);
        Assert.Contains(nameof(ImplantType.Cyberlimb), names);
        Assert.Contains(nameof(ImplantType.SubdermalArmor), names);
        Assert.Contains(nameof(ImplantType.Biomonitor), names);
    }
}
