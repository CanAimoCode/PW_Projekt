using System.Reflection;
using Interfaces;

namespace BLC;

public sealed class BLC
{
    private static BLC? _instance;

    private readonly IDAO _dao;

    private BLC(IDAO dao) => _dao = dao;

    // Bez blokady dwie sesje równolegle mogą utworzyć dwie instancje (lab. 3 zad. 5).
    public static BLC Instance(string daoLibraryPath) => _instance ??= new BLC(LoadDao(daoLibraryPath));

    public IEnumerable<IProducer> GetAllProducers() => _dao.GetAllProducers();

    public IEnumerable<IProduct> GetAllProducts() => _dao.GetAllProducts();

    public static IDAO LoadDao(string daoLibraryPath)
    {
        if (!File.Exists(daoLibraryPath))
        {
            throw new FileNotFoundException($"Nie znaleziono biblioteki DAO: {daoLibraryPath}", daoLibraryPath);
        }

        var assembly = Assembly.UnsafeLoadFrom(daoLibraryPath);

        var daoType = assembly.GetTypes()
            .FirstOrDefault(t => !t.IsInterface && !t.IsAbstract && typeof(IDAO).IsAssignableFrom(t))
            ?? throw new InvalidOperationException(
                $"Biblioteka {daoLibraryPath} nie zawiera typu implementującego {nameof(IDAO)}.");

        return (IDAO)Activator.CreateInstance(daoType)!;
    }
}
