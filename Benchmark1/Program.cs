using BenchmarkDotNet.Running;

namespace LoggingBenchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkDotNet.Reports.Summary[] summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
