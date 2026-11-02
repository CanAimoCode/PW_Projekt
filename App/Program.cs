using System.Configuration;
using Blc = BLC.BLC;

namespace App;

public static class Program
{
    public static void Main()
    {
        var libraryName = ConfigurationManager.AppSettings["daoLibrary"]
            ?? throw new InvalidOperationException("Brak ustawienia 'daoLibrary' w App.config.");

        var blc = Blc.Instance(libraryName);

        Console.WriteLine($"BIBLIOTEKA: {libraryName}");
        Console.WriteLine("KORPORACJE:");
        foreach (var producer in blc.Dao.GetAllProducers())
        {
            Console.WriteLine($"  {producer}");
        }

        Console.WriteLine("IMPLANTY:");
        foreach (var implant in blc.Dao.GetAllImplants())
        {
            Console.WriteLine($"  {implant}");
        }
    }
}
