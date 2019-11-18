using System;
using Xunit;

namespace LoggingTests
{
    public class SerilogTests : IDisposable
    {
        private readonly Serilog.Core.Logger factory;
        private readonly Serilog.ILogger logger;

        public SerilogTests(SerilogConfiguration configuration = null)
        {
            factory = LoggerBuilders.BuildSerilogLogFactory(configuration);
            logger = factory.ForContext<IAuditLogger>();
        }

        [Fact]
        public void TestCase1()
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
