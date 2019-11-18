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
        private Log4NetTests log4NetTests;
        private Log4NetTests log4NetLockingModelExclusiveTests;

        [GlobalSetup]
        public void GlobalSetup()
        {
            serilogBaseTests = new SerilogTests();
            serilogBufferedTests = new SerilogTests(new SerilogConfiguration { Buffered = true });
            nLogKeepFileOpenAutoFlushTests = new NLogTests(new NLogConfiguration { KeepFileOpen = true, AutoFlush = true });
            nLogAutoFlushTests = new NLogTests(new NLogConfiguration { KeepFileOpen = false, AutoFlush = true });
            nLogKeepFileOpenTests = new NLogTests(new NLogConfiguration { KeepFileOpen = true, AutoFlush = false });
            nLogTests = new NLogTests(new NLogConfiguration { KeepFileOpen = false, AutoFlush = false });
            log4NetTests = new Log4NetTests(new Log4NetConfiguration { InstanceName = "Audit" });
            log4NetLockingModelExclusiveTests = new Log4NetTests(new Log4NetConfiguration { InstanceName = "AuditExclusive", LockingModel = new log4net.Appender.FileAppender.ExclusiveLock() });
        }

        [Benchmark]
        public void Log4Net()
        {
            log4NetTests.TestCase1();
        }

        [Benchmark]
        public void Log4NetLockingModelExclusive()
        {
            log4NetLockingModelExclusiveTests.TestCase1();
        }

        [Benchmark]
        public void NLogKeepFileOpenAutoFlush()
        {
            nLogKeepFileOpenAutoFlushTests.TestCase1();
        }

        [Benchmark]
        public void NLog()
        {
            nLogTests.TestCase1();
        }

        [Benchmark]
        public void NLogAutoFlush()
        {
            nLogAutoFlushTests.TestCase1();
        }

        [Benchmark]
        public void NLogKeepFileOpen()
        {
            nLogKeepFileOpenTests.TestCase1();
        }

        [Benchmark(Baseline = true)]
        public void Serilog()
        {
            serilogBaseTests.TestCase1();
        }

        [Benchmark()]
        public void SerilogBuffered()
        {
            serilogBufferedTests.TestCase1();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            serilogBaseTests.Dispose();
            nLogKeepFileOpenAutoFlushTests.Dispose();
        }
    }
}
