using DAOMock;
using Interfaces;

namespace Tests;

public class DaoTests
{
    private readonly DAO _dao = new();

    [Fact]
    public void GetAllProducers_returns_the_seeded_corporations()
    {
        var producers = _dao.GetAllProducers().ToList();

        Assert.NotEmpty(producers);
        var arasaka = Assert.Single(producers.Where(p => p.Name == "Arasaka"));
        Assert.Equal("Tokio", arasaka.HeadQuarters);
    }

    [Fact]
    public void GetAllProducts_returns_implants_of_known_types()
    {
        var products = _dao.GetAllProducts().ToList();

        Assert.NotEmpty(products);
        Assert.All(products, p => Assert.True(Enum.IsDefined(p.Type)));
        Assert.All(products, p => Assert.True(p.Price > 0));
    }

    [Fact]
    public void Every_product_belongs_to_a_known_producer()
    {
        var producerNames = _dao.GetAllProducers().Select(p => p.Name).ToHashSet();

        Assert.All(_dao.GetAllProducts(), p => Assert.Contains(p.ProducerName, producerNames));
    }
}
