using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using Test1;

namespace Benchmark1
{
    [CoreJob, RPlotExporter]
    public class Benchmarks
    {
        private SerilogTests serilogBaseTests;
        private SerilogTests serilogBufferedTests;
        private NLogTests nLogKeepFileOpenAutoFlushTests;
        private NLogTests nLogAutoFlushTests;
        private NLogTests nLogKeepFileOpenTests;
        private NLogTests nLogTests;

        [GlobalSetup]
        public void GlobalSetup()
        {
            serilogBaseTests = new SerilogTests();
            serilogBufferedTests = new SerilogTests(new Configuration { Buffered = true });
            nLogKeepFileOpenAutoFlushTests = new NLogTests(new Configuration { KeepFileOpen = true, AutoFlush = true });
            nLogAutoFlushTests = new NLogTests(new Configuration { KeepFileOpen = false, AutoFlush = true });
            nLogKeepFileOpenTests = new NLogTests(new Configuration { KeepFileOpen = true, AutoFlush = false });
            nLogTests = new NLogTests(new Configuration { KeepFileOpen = false, AutoFlush = false });
        }

        [Benchmark]
        public void NLogKeepFileOpenAutoFlush()
        {
            nLogKeepFileOpenAutoFlushTests.TestNLog();
        }

        [Benchmark]
        public void NLog()
        {
            nLogTests.TestNLog();
        }

        [Benchmark]
        public void NLogAutoFlush()
        {
            nLogAutoFlushTests.TestNLog();
        }

        [Benchmark]
        public void NLogKeepFileOpen()
        {
            nLogKeepFileOpenTests.TestNLog();
        }

        [Benchmark(Baseline = true)]
        public void Serilog()
        {
            serilogBaseTests.TestSerilog();
        }

        [Benchmark()]
        public void SerilogBuffered()
        {
            serilogBufferedTests.TestSerilog();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            serilogBaseTests.Dispose();
            nLogKeepFileOpenAutoFlushTests.Dispose();
        }
    }
}
