using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using LoggingTests;
using System.Collections.Generic;
using System.Linq;
using static LoggingBenchmarks.FileMode;

namespace LoggingBenchmarks
{
    public class SingleThreadBenchmarks
    {
        private SerilogTests serilogBaseTests;
        private NLogTests nLogTests;
        private Log4NetTests log4NetTests;

        [Params(None, KeepFileOpen, KeepFileOpenBuffered, KeepFileOpenShared)]
        public virtual FileMode FileMode { get; set; }

        #region Setup
        [GlobalSetup(Target = nameof(Log4Net))]
        public void Log4NetGlobalSetup()
        {
            log4NetTests = new Log4NetTests(new Log4NetConfiguration { Buffered = FileMode.HasFlag(Buffered), KeepFileOpen = FileMode.HasFlag(KeepFileOpen), Shared = FileMode.HasFlag(Shared) });
        }

        [GlobalSetup(Target = nameof(NLog))]
        public void NLogGlobalSetup()
        {
            nLogTests = new NLogTests(new NLogConfiguration { Buffered = FileMode.HasFlag(Buffered), KeepFileOpen = FileMode.HasFlag(KeepFileOpen), Shared = FileMode.HasFlag(Shared) });
        }

        [GlobalSetup(Target = nameof(Serilog))]
        public void SerilogGlobalSetup()
        {
            serilogBaseTests = new SerilogTests(new SerilogConfiguration { Buffered = FileMode.HasFlag(Buffered), Shared = FileMode.HasFlag(Shared) });
        }
        #endregion

        [Benchmark(Baseline = true)]
        public void Serilog()
        {
            serilogBaseTests.TestCase1();
        }

        [Benchmark]
        public void NLog()
        {
            nLogTests.TestCase1();
        }

        [Benchmark]
        public void Log4Net()
        {
            log4NetTests.TestCase1();
        }

        #region Cleanup

        [GlobalCleanup(Target = nameof(Log4Net))]
        public void Log4NetGlobalCleanup()
        {
            log4NetTests.Dispose();
        }

        [GlobalCleanup(Target = nameof(NLog))]
        public void NLogGlobalCleanup()
        {
            nLogTests.Dispose();
        }

        [GlobalCleanup(Target = nameof(Serilog))]
        public void SerilogGlobalCleanup()
        {
            serilogBaseTests.Dispose();
        }
        #endregion
    }
}
