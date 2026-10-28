namespace Interfaces;

public interface IProduct
{
    string Name { get; }
    ImplantType Type { get; }
    decimal Price { get; }
    string ProducerName { get; }
}
