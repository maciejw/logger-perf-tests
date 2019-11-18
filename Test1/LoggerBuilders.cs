using System;
using Serilog;

namespace LoggingTests
{
    public static class LoggerBuilders
    {
        public static Serilog.Core.Logger BuildSerilogLogFactory(SerilogConfiguration configuration = null)
        {
            (bool Buffered, bool Shared) = configuration ?? new SerilogConfiguration();

            return new Serilog.LoggerConfiguration()
               .WriteTo.File(
                new Serilog.Formatting.Compact.CompactJsonFormatter(),
                $"./serilog/audit-{DateTime.Now.ToString("yyyyMMddHHmm")}-latest.log",
                Serilog.Events.LogEventLevel.Verbose,
                100_000_000,

                buffered: Buffered,

                shared: Shared,
                rollingInterval: Serilog.RollingInterval.Day,
                rollOnFileSizeLimit: true)
               .CreateLogger();
        }

        public static NLog.LogFactory BuildNLogFactory(NLogConfiguration configuration = null)
        {
            NLog.Layouts.JsonLayout jsonLayout = new NLog.Layouts.JsonLayout
            {
                IncludeAllProperties = true,
                Attributes = {
                    new NLog.Layouts.JsonAttribute("@t", "${longdate}"),
                    new NLog.Layouts.JsonAttribute("@l", "${level:upperCase=true}"),
                    new NLog.Layouts.JsonAttribute("@mt", "${message:raw=true}"),
                }
            };

            (bool Buffered, bool KeepFileOpen, bool Shared) = configuration ?? new NLogConfiguration();

            bool AutoFlush = !Buffered;

            NLog.Targets.FileTarget fileTarget = new NLog.Targets.FileTarget("audit-log")
            {
                FileName = "${currentdir}/nlog/audit-${date:format=yyyyMMddHHmm}-latest.log",

                AutoFlush = AutoFlush,
                KeepFileOpen = KeepFileOpen,

                ConcurrentWrites = Shared,
                ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Rolling,
                ArchiveAboveSize = 100_000_000,
                ArchiveFileName = "${currentdir}/nlog/audit-${date:format=yyyyMMddHHmm}-{###}.log",
                Layout = jsonLayout
            };

            NLog.Config.LoggingConfiguration loggingConfiguration = new NLog.Config.LoggingConfiguration();

            loggingConfiguration.AddTarget(fileTarget);

            loggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Info, fileTarget);

            return new NLog.LogFactory(loggingConfiguration)
            {
                ThrowExceptions = true,
                ThrowConfigExceptions = true,
            };
        }

        public static string BuildLog4Net(Log4NetConfiguration configuration = null)
        {
            log4net.Layout.SerializedLayout layout = new log4net.Layout.SerializedLayout();
            layout.AddDecorator(new log4net.Layout.Decorators.StandardTypesDecorator());
            layout.AddDefault("");
            layout.AddRemove("message");
            layout.AddMember("messageobject");
            layout.ActivateOptions();

            log4net.Filter.LevelMatchFilter filter = new log4net.Filter.LevelMatchFilter
            {
                LevelToMatch = log4net.Core.Level.All
            };
            filter.ActivateOptions();

            (string InstanceName, bool Buffered, bool KeepFileOpen) = configuration ?? new Log4NetConfiguration();

            log4net.Appender.FileAppender.LockingModelBase LockingModel = new log4net.Appender.FileAppender.MinimalLock();
            if (KeepFileOpen)
            {
                LockingModel = new log4net.Appender.FileAppender.ExclusiveLock();
            }

            bool ImmediateFlush = !Buffered;

            log4net.Appender.RollingFileAppender rollingFileAppender = new log4net.Appender.RollingFileAppender
            {
                File = $@"log4net\{InstanceName.ToLower()}-{DateTime.Now.ToString("yyyyMMddHHmm")}-latest.log",

                ImmediateFlush = ImmediateFlush,
                LockingModel = LockingModel,

                AppendToFile = true,
                RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite,
                DatePattern = "yyyyMMddhhmm",
                MaxFileSize = 100_000_000,
                Name = $"{InstanceName}Appender",
                Layout = layout
            };
            rollingFileAppender.AddFilter(filter);
            rollingFileAppender.ActivateOptions();

            string Repository = $"{InstanceName}Repository";
            log4net.Repository.ILoggerRepository repository = log4net.Core.LoggerManager.CreateRepository(Repository);

            log4net.Config.BasicConfigurator.Configure(repository, rollingFileAppender);

            return Repository;
        }
    }
}
