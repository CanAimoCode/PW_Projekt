using DAOMock2.BO;
using Interfaces;

namespace DAOMock2;

public class DAO : IDAO
{
    private readonly List<Producer> _producers;
    private readonly List<Implant> _products;

    public DAO()
    {
        _producers =
        [
            new Producer("Zetatech", "Night City", 90_000),
            new Producer("Dynalar", "Los Angeles", 60_000),
            new Producer("Raven Microcybernetics", "Londyn", 75_000),
            new Producer("Biodyne", "Nowy Jork", 45_000)
        ];

        _products =
        [
            new Implant("Reflex Tuner", ImplantType.NeuralProcessor, 8_000m, "Zetatech"),
            new Implant("Zetatech Cyberdeck", ImplantType.NeuralProcessor, 22_000m, "Zetatech"),
            new Implant("Cyberaudio Suite", ImplantType.Cyberaudio, 7_500m, "Dynalar"),
            new Implant("Voice Synthesizer", ImplantType.Cyberaudio, 4_000m, "Dynalar"),
            new Implant("Kiroshi Alternative Optics", ImplantType.Cyberoptics, 9_800m, "Raven Microcybernetics"),
            new Implant("Subdermal Plating", ImplantType.SubdermalArmor, 12_500m, "Raven Microcybernetics"),
            new Implant("Blood Pump", ImplantType.Biomonitor, 4_500m, "Biodyne"),
            new Implant("Reinforced Tendons", ImplantType.Cyberlimb, 16_000m, "Biodyne")
        ];
    }

    public IEnumerable<IProducer> GetAllProducers() => _producers;

    public IEnumerable<IProduct> GetAllProducts() => _products;
}
