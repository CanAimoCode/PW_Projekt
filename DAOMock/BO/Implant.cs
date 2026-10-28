using System.Globalization;
using Interfaces;

namespace DAOMock.BO;

public class Implant : IProduct
{
    public string Name { get; }
    public ImplantType Type { get; }
    public decimal Price { get; }
    public string ProducerName { get; }

    public Implant(string name, ImplantType type, decimal price, string producerName)
    {
        Name = name;
        Type = type;
        Price = price;
        ProducerName = producerName;
    }

    public override string ToString() =>
        $"{Name} [{Type}] €${Price.ToString("N2", CultureInfo.InvariantCulture)} ({ProducerName})";
}
