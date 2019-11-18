using System;
using Xunit;

namespace LoggingTests
{
    public class Log4NetTests : IDisposable
    {
        private readonly string Repository;
        private readonly log4net.ILog logger;

        public Log4NetTests(Log4NetConfiguration configuration = null)
        {
            Repository = LoggerBuilders.BuildLog4Net(configuration);

            logger = log4net.LogManager.GetLogger(Repository, typeof(IAuditLogger));
        }

        [Fact]
        public void TestCase1()
        {
            TestsCases.TestCase1((message, i, data) => logger.Info(new { message, i, data }), (message, elapsedMilliseconds, count) => logger.Info(new { message, elapsedMilliseconds, count }));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    log4net.LogManager.ShutdownRepository(Repository);
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
