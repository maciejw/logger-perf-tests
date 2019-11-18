using System;
using System.Diagnostics;
using Xunit;

namespace Test1
{
    public class SerilogTests : IDisposable
    {
        private readonly Serilog.Core.Logger factory;
        private readonly Serilog.ILogger logger;

        public SerilogTests()
        {
            factory = LoggerBuilders.BuildSerilogLogFactory();
            logger = factory.ForContext<IAuditLogger>();
        }

        [Fact]
        public void TestSerilog()
        {
            TestsCases.TestCase1(logger.Information, logger.Information);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    factory.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
