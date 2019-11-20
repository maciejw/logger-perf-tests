using System;

namespace LoggingTests
{
    public class Log4NetTests : LoggerTests, IDisposable
    {
        private readonly string Repository;
        private readonly log4net.ILog logger;

        public Log4NetTests(Log4NetConfiguration configuration = null)
        {
            Repository = LoggerBuilders.BuildLog4Net(configuration ?? new Log4NetConfiguration { InstanceName = $"{Guid.NewGuid()}", KeepFileOpen = true });

            logger = log4net.LogManager.GetLogger(Repository, typeof(IAuditLogger));
        }

        protected override LogFinish LogFinish => (message, elapsedMilliseconds, count) => logger.Info(new { message, elapsedMilliseconds, count });

        protected override LogEntry LogEntry => (message, i, data) => logger.Info(new { message, i, data });

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
