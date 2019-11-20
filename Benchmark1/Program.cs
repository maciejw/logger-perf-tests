using BenchmarkDotNet.Running;

namespace LoggingBenchmarks
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SingleThreadBenchmarks>(new BenchmarkConfig());
        }
    }
}
