using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace IllusionistSoft.AsyncExtensions.Benchmark
{
    [MemoryDiagnoser]
    public class AwaitVsIsCompleted
    {
        private const int Count = 100_000;

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
            for (int i = 0; i < Count; i++)
            {
                yield return await Get(0);
            }
        }

        private async IAsyncEnumerable<int> GetHalfAwait()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                yield return await Get(0);
            }

            for (int i = 0; i < Count / 2; i++)
            {
                yield return await Get(1000);
            }
        }

        private async IAsyncEnumerable<int> GetAllAwait()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return await Get(1000);
            }
        }

        private async ValueTask<int> Get(int value)
        {
            if (value == 0)
            {
                await Task.Delay(value);
            }
            else
            {
                await Task.Yield();
            }
            return 1;
        }
    }
}