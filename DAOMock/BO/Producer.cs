using Interfaces;

namespace DAOMock.BO;

public class Producer : IProducer
{
    public string Name { get; }
    public string HeadQuarters { get; }
    public int Employees { get; }

    public Producer(string name, string headQuarters, int employees)
    {
        Name = name;
        HeadQuarters = headQuarters;
        Employees = employees;
    }

    public override string ToString() => $"{Name} ({HeadQuarters}, {Employees} pracowników)";
}
