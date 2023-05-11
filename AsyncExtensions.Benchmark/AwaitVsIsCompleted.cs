using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace IllusionistSoft.AsyncExtensions.Benchmark;

[MemoryDiagnoser]
public class AwaitVsIsCompleted
{
    [Params(10, 1_000, 10_000, 100_000)]
    public int Count;

    [Benchmark]
    public async Task AllNotAwaitSimple() => await GetAll().SimpleToListAsync();
    [Benchmark]
    public async Task AllNotAwaitTask() => await GetAll().ToListAsync();
    [Benchmark]
    public async Task AllNotAwaitValueTask() => await GetAll().ToListValueTaskAsync();


    [Benchmark]
    public async Task AllAwaitSimple() => await GetAllAwait().SimpleToListAsync();
    [Benchmark]
    public async Task AllAwaitTask() => await GetAllAwait().ToListAsync();
    [Benchmark]
    public async Task AllAwaitValueTask() => await GetAllAwait().ToListValueTaskAsync();


    [Benchmark]
    public async Task HalfAwaitHalfNotAwaitSimple() => await GetHalfAwait().SimpleToListAsync();
    [Benchmark]
    public async Task HalfAwaitHalfNotAwaitTask() => await GetHalfAwait().ToListAsync();
    [Benchmark]
    public async Task HalfAwaitHalfNotAwaitValueTask() => await GetHalfAwait().ToListValueTaskAsync();


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
