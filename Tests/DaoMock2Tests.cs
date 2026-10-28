using Interfaces;
using Dao2 = DAOMock2.DAO;
using Dao1 = DAOMock.DAO;

namespace Tests;

public class DaoMock2Tests
{
    [Fact]
    public void DAOMock2_implements_IDAO_with_data()
    {
        IDAO dao = new Dao2();

        Assert.NotEmpty(dao.GetAllProducers());
        Assert.NotEmpty(dao.GetAllProducts());
    }

    [Fact]
    public void DAOMock2_serves_different_data_than_DAOMock()
    {
        var secondNames = new Dao2().GetAllProducers().Select(p => p.Name).ToHashSet();
        var firstNames = new Dao1().GetAllProducers().Select(p => p.Name).ToHashSet();

        Assert.NotEmpty(secondNames.Except(firstNames));
        Assert.NotEmpty(firstNames.Except(secondNames));
    }

    [Fact]
    public void DAOMock2_implant_ToString_uses_eurodollars()
    {
        var implant = new DAOMock2.BO.Implant("Reflex Tuner", ImplantType.NeuralProcessor, 18_000m, "Zetatech");

        var text = implant.ToString();

        Assert.Contains("€$18,000.00", text);
        Assert.DoesNotContain("zł", text);
    }

    [Fact]
    public void DAOMock2_products_belong_to_its_own_producers()
    {
        var dao = new Dao2();
        var producerNames = dao.GetAllProducers().Select(p => p.Name).ToHashSet();

        Assert.All(dao.GetAllProducts(), p => Assert.Contains(p.ProducerName, producerNames));
    }
}
