using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using Test1;

namespace Benchmark1
{
    [CoreJob, RPlotExporter]
    public class Benchmarks
    {
        private SerilogTests serilogTests;
        private NLogTests nLogTests;

        [GlobalSetup]
        public void GlobalSetup()
        {
            serilogTests = new SerilogTests();
            nLogTests = new NLogTests();
        }

        [Benchmark]
        public void LogNLog()
        {
            nLogTests.TestNLog();
        }

        [Benchmark(Baseline = true)]
        public void LogSerilog()
        {
            serilogTests.TestSerilog();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            serilogTests.Dispose();
            nLogTests.Dispose();
        }
    }
}
