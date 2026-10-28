using System.Configuration;
using Blc = BLC.BLC;

namespace App;

public static class Program
{
    public static void Main()
    {
        var libraryName = ConfigurationManager.AppSettings["daoLibrary"]
            ?? throw new InvalidOperationException("Brak ustawienia 'daoLibrary' w App.config.");

        var blc = Blc.Instance(Path.Combine(AppContext.BaseDirectory, libraryName));

        Console.WriteLine($"BIBLIOTEKA: {libraryName}");
        Console.WriteLine("KORPORACJE:");
        foreach (var producer in blc.GetAllProducers())
        {
            Console.WriteLine($"  {producer}");
        }

        Console.WriteLine("IMPLANTY:");
        foreach (var product in blc.GetAllProducts())
        {
            Console.WriteLine($"  {product}");
        }
    }
}
