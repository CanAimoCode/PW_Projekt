namespace Interfaces;

public interface IDAO
{
    IEnumerable<IProducer> GetAllProducers();
    IEnumerable<IImplant> GetAllImplants();
}
