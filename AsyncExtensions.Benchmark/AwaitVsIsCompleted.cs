using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace IllusionistSoft.AsyncExtensions.Benchmark;

[MemoryDiagnoser]
public class AwaitVsIsCompleted
{
    [Params(10, 1_000, 100_000)]
    public int Count;

    [Benchmark]
    public async Task ToListAll() => await GetAll().ToListAsync();

    [Benchmark]
    public async Task SimpleToListAll() => await GetAll().SimpleToListAsync();


    [Benchmark]
    public async Task ToListAllAwait() => await GetAllAwait().ToListAsync();

    [Benchmark]
    public async Task SimpleToListAllAwait() => await GetAllAwait().SimpleToListAsync();


    [Benchmark]
    public async Task ToListAllHalfAwait() => await GetHalfAwait().ToListAsync();

    [Benchmark]
    public async Task SimpleToListAllHalfAwait() => await GetHalfAwait().SimpleToListAsync();


    private async IAsyncEnumerable<int> GetAll()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return await Get(false);
        }
    }

    private async IAsyncEnumerable<int> GetHalfAwait()
    {
        for (var i = 0; i < Count / 2; i++)
        {
            yield return await Get(false);
        }

        for (var i = 0; i < Count / 2; i++)
        {
            yield return await Get(true);
        }
    }

    private async IAsyncEnumerable<int> GetAllAwait()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return await Get(true);
        }
    }

    private static async Task<int> Get(bool yield)
    {
        if (yield)
        {
            await Task.Yield();
        }

        return 1;
    }
}
