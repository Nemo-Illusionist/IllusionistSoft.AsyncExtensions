using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IllusionistSoft.AsyncExtensions;

public static class AsyncEnumerableExtensions
{
    public static Task<List<T>> ToListAsync<T>(
        this IAsyncEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        var list = new List<T>();

        Task? disposedTask = null;
        var enumerator = source.GetAsyncEnumerator(cancellationToken);
        try
        {
            bool isResult;
            do
            {
                var task = enumerator.MoveNextAsync();
                if (task.IsCompletedSuccessfully)
                {
                    isResult = task.Result;
                    if (isResult)
                    {
                        list.Add(enumerator.Current);
                    }
                }
                else
                {
                    var result = WaitEnumeratorAsync(task.AsTask(), list, enumerator);
                    enumerator = null;
                    return result;
                }
            } while (isResult);
        }
        catch (Exception exception)
        {
            return Task.FromException<List<T>>(exception);
        }
        finally
        {
            if (enumerator != null)
            {
                var task = enumerator.DisposeAsync();
                if (task.IsCompletedSuccessfully)
                {
                    task.GetAwaiter().GetResult();
                }
                else
                {
                    disposedTask = task.AsTask();
                }
            }
        }

        return disposedTask == null ? Task.FromResult(list) : WaitDisposeAsync(disposedTask, list);

        static async Task<List<T>> WaitDisposeAsync(Task task, List<T> list)
        {
            await task.ConfigureAwait(false);
            return list;
        }

        static async Task<List<T>> WaitEnumeratorAsync(
            Task<bool> task,
            List<T> list,
            IAsyncEnumerator<T> enumerator)
        {
            await using (enumerator)
            {
                var isResult = await task.ConfigureAwait(false);
                if (isResult)
                {
                    list.Add(enumerator.Current);

                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        list.Add(enumerator.Current);
                    }
                }
            }

            return list;
        }
    }

    public static Task<T[]> ToArrayAsync<T>(
        this IAsyncEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        Task<List<T>> task;
        try
        {
            task = ToListAsync(source, cancellationToken);
        }
        catch (Exception ex)
        {
            return Task.FromException<T[]>(ex);
        }

        if (task.IsCompletedSuccessfully)
        {
            return Task.FromResult(task.Result.ToArray());
        }
        else
        {
            return WaitAsync(task);
        }

        static async Task<T[]> WaitAsync(Task<List<T>> task)
        {
            var list = await task.ConfigureAwait(false);
            return list.ToArray();
        }
    }
}
