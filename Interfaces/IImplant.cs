namespace Interfaces;

public interface IImplant
{
    string Name { get; }
    ImplantType Type { get; }
    decimal Price { get; }
    string ProducerName { get; }
}
