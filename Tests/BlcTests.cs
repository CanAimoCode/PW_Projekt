using Interfaces;
using Blc = BLC.BLC;

namespace Tests;

public class BlcTests
{
    private static string DaoMockPath => typeof(DAOMock.DAO).Assembly.Location;
    private static string DaoMock2Path => typeof(DAOMock2.DAO).Assembly.Location;

    [Fact]
    public void LoadDao_reads_the_first_mock_library()
    {
        IDAO dao = Blc.LoadDao(DaoMockPath);

        Assert.Contains(dao.GetAllProducers(), p => p.Name == "Arasaka");
    }

    [Fact]
    public void LoadDao_reads_the_second_mock_library()
    {
        IDAO dao = Blc.LoadDao(DaoMock2Path);

        Assert.Contains(dao.GetAllProducers(), p => p.Name == "Zetatech");
    }

    [Fact]
    public void LoadDao_throws_when_the_file_does_not_exist()
    {
        Assert.Throws<FileNotFoundException>(() => Blc.LoadDao(@"C:\nie\ma\takiej.dll"));
    }

    [Fact]
    public void LoadDao_throws_when_the_library_has_no_idao_implementation()
    {
        var interfacesOnly = typeof(IDAO).Assembly.Location;

        Assert.Throws<InvalidOperationException>(() => Blc.LoadDao(interfacesOnly));
    }

    [Fact]
    public void Instance_returns_the_same_singleton_and_serves_data()
    {
        var first = Blc.Instance(DaoMockPath);
        var second = Blc.Instance(DaoMock2Path);

        Assert.Same(first, second);
        Assert.NotEmpty(first.GetAllProducers());
        Assert.NotEmpty(first.GetAllProducts());
    }
}
