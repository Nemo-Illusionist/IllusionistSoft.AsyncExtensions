using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IllusionistSoft.AsyncExtensions.UnitTests;

public class SimpleTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ToListTest()
    {
        await GetAll().ToListAsync();
    }

    [Test]
    public async Task ToArrayTest()
    {
        await GetAll().ToArrayAsync();
    }

    private async IAsyncEnumerable<int> GetAll()
    {
        yield return await Get(0);
        yield return await Get(10000);
    }

    private async Task<int> Get(int value)
    {
        await Task.Delay(value);
        return 1;
    }
}