using DAOMock.BO;
using Interfaces;

namespace DAOMock;

public class DAO : IDAO
{
    private readonly List<Producer> _producers;
    private readonly List<Implant> _products;

    public DAO()
    {
        _producers =
        [
            new Producer("Arasaka", "Tokio", 900_000),
            new Producer("Militech", "Waszyngton", 650_000),
            new Producer("Kang Tao", "Szanghaj", 400_000),
            new Producer("Biotechnica", "Rzym", 120_000)
        ];

        _products =
        [
            new Implant("Sandevistan", ImplantType.NeuralProcessor, 25_000m, "Arasaka"),
            new Implant("Kerenzikov", ImplantType.NeuralProcessor, 12_000m, "Arasaka"),
            new Implant("Mantis Blades", ImplantType.Cyberlimb, 40_000m, "Militech"),
            new Implant("Gorilla Arms", ImplantType.Cyberlimb, 35_000m, "Militech"),
            new Implant("Kiroshi Optics Mk.3", ImplantType.Cyberoptics, 8_000m, "Kang Tao"),
            new Implant("Smart Link", ImplantType.Cyberoptics, 6_500m, "Kang Tao"),
            new Implant("Biomonitor", ImplantType.Biomonitor, 4_000m, "Biotechnica"),
            new Implant("Subdermal Armor", ImplantType.SubdermalArmor, 15_000m, "Biotechnica")
        ];
    }

    public IEnumerable<IProducer> GetAllProducers() => _producers;

    public IEnumerable<IProduct> GetAllProducts() => _products;
}
