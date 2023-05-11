using System.Collections.Generic;
using System.Threading.Tasks;

namespace IllusionistSoft.AsyncExtensions.Benchmark;

internal static class SimpleAsyncEnumerableExtensions
{
    public static async Task<List<T>> SimpleToListAsync<T>(this IAsyncEnumerable<T> source)
    {
        var list = new List<T>();
        await foreach (var item in source.ConfigureAwait(false))
        {
            list.Add(item);
        }

        return list;
    }

    public static async Task<T[]> SimpleToArrayAsync<T>(this IAsyncEnumerable<T> source)
    {
        var list = await SimpleToListAsync(source).ConfigureAwait(false);
        return list.ToArray();
    }
}
