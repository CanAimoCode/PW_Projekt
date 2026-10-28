using DAOMock.BO;
using Interfaces;

namespace Tests;

public class BoTests
{
    [Fact]
    public void Producer_exposes_values_passed_to_constructor()
    {
        var producer = new Producer("Arasaka", "Tokio", 1_000_000);

        Assert.Equal("Arasaka", producer.Name);
        Assert.Equal("Tokio", producer.HeadQuarters);
        Assert.Equal(1_000_000, producer.Employees);
    }

    [Fact]
    public void Implant_exposes_values_passed_to_constructor()
    {
        var implant = new Implant("Sandevistan", ImplantType.NeuralProcessor, 25_000m, "Arasaka");

        Assert.Equal("Sandevistan", implant.Name);
        Assert.Equal(ImplantType.NeuralProcessor, implant.Type);
        Assert.Equal(25_000m, implant.Price);
        Assert.Equal("Arasaka", implant.ProducerName);
    }

    [Fact]
    public void Producer_ToString_contains_name_and_headquarters()
    {
        var producer = new Producer("Militech", "Waszyngton", 500_000);

        var text = producer.ToString();

        Assert.Contains("Militech", text);
        Assert.Contains("Waszyngton", text);
    }

    [Fact]
    public void Implant_ToString_formats_price_in_eurodollars()
    {
        var implant = new Implant("Sandevistan", ImplantType.NeuralProcessor, 25_000m, "Arasaka");

        Assert.Contains("€$25,000.00", implant.ToString());
    }

    [Fact]
    public void Implant_ToString_contains_name_type_and_producer()
    {
        var implant = new Implant("Mantis Blades", ImplantType.Cyberlimb, 40_000m, "Militech");

        var text = implant.ToString();

        Assert.Contains("Mantis Blades", text);
        Assert.Contains(nameof(ImplantType.Cyberlimb), text);
        Assert.Contains("Militech", text);
    }
}
