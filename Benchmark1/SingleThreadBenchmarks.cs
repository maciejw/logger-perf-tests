using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using LoggingTests;

namespace LoggingBenchmarks
{
    [RPlotExporter]
    [SimpleJob(RuntimeMoniker.NetCoreApp21)]
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    public class SingleThreadBenchmarks
    {
        private SerilogTests serilogBaseTests;
        private NLogTests nLogTests;
        private Log4NetTests log4NetTests;

        [Params(true, false)]
        public bool KeepFileOpen { get; set; }

        [Params(true, false)]
        public bool Buffered { get; set; }

        #region Setup
        [GlobalSetup(Target = nameof(Log4Net))]
        public void Log4NetGlobalSetup()
        {
            log4NetTests = new Log4NetTests(new Log4NetConfiguration { Buffered = Buffered, KeepFileOpen = KeepFileOpen });
        }

        [GlobalSetup(Target = nameof(NLog))]
        public void NLogGlobalSetup()
        {
            nLogTests = new NLogTests(new NLogConfiguration { Buffered = Buffered, KeepFileOpen = KeepFileOpen });
        }

        [GlobalSetup(Target = nameof(Serilog))]
        public void SerilogGlobalSetup()
        {
            serilogBaseTests = new SerilogTests(new SerilogConfiguration { Buffered = Buffered });
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
