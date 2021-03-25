using BenchmarkDotNet.Running;

namespace IllusionistSoft.AsyncExtensions.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<AwaitVsIsCompleted>();
        }
    }
}