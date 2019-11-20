using System;

namespace LoggingTests
{
    public class NLogTests : LoggerTests, IDisposable
    {
        private readonly NLog.LogFactory factory;
        private readonly NLog.Logger logger;

        public NLogTests(NLogConfiguration configuration = null)
        {
            factory = LoggerBuilders.BuildNLogFactory(configuration ?? new NLogConfiguration { KeepFileOpen = true });
            logger = factory.GetLogger(nameof(IAuditLogger));
        }

        protected override LogEntry LogEntry => logger.Info;
        protected override LogFinish LogFinish => logger.Info;

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
