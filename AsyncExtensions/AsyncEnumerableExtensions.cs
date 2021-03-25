using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IllusionistSoft.AsyncExtensions
{
    public static class AsyncEnumerableExtensions
    {
        public static ValueTask<List<T>> ToListAsync<T>(
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
                        var result = WaitEnumeratorAsync(task, list, enumerator);
                        enumerator = null;
                        return result;
                    }
                } while (isResult);
            }
            catch (Exception exception)
            {
                return new ValueTask<List<T>>(Task.FromException<List<T>>(exception));
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

            return disposedTask == null ? new ValueTask<List<T>>(list) : WaitDisposeAsync(disposedTask, list);

            static async ValueTask<List<T>> WaitDisposeAsync(Task task, List<T> list)
            {
                await task.ConfigureAwait(false);
                return list;
            }

            static async ValueTask<List<T>> WaitEnumeratorAsync(
                ValueTask<bool> task,
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

        public static ValueTask<T[]> ToArrayAsync<T>(
            this IAsyncEnumerable<T> source,
            CancellationToken cancellationToken = default)
        {
            ValueTask<List<T>> task;
            try
            {
                task = ToListAsync(source, cancellationToken);
            }
            catch (Exception ex)
            {
                return new ValueTask<T[]>(Task.FromException<T[]>(ex));
            }

            if (task.IsCompletedSuccessfully)
            {
                return new ValueTask<T[]>(task.Result.ToArray());
            }
            else
            {
                return WaitAsync(task);
            }

            static async ValueTask<T[]> WaitAsync(ValueTask<List<T>> task)
            {
                var list = await task.ConfigureAwait(false);
                return list.ToArray();
            }
        }
    }
}