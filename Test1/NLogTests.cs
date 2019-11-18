using System;
using Xunit;

namespace LoggingTests
{
    public class NLogTests : IDisposable
    {
        private readonly NLog.LogFactory factory;
        private readonly NLog.Logger logger;

        public NLogTests(NLogConfiguration configuration = null)
        {
            factory = LoggerBuilders.BuildNLogFactory(configuration);
            logger = factory.GetLogger(nameof(IAuditLogger));
        }

        [Fact]
        public void TestCase1()
        {
            TestsCases.TestCase1(logger.Info, logger.Info);
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
