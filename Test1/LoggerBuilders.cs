using System;
using Serilog;

namespace Test1
{
    public class Configuration
    {
        /// <summary>
        /// Serilog
        /// </summary>
        public bool Buffered { get; set; }
        /// <summary>
        /// Serilog, NLog
        /// </summary>
        public bool Shared { get; set; }
        /// <summary>
        /// NLog
        /// </summary>
        public bool AutoFlush { get; set; }
        /// <summary>
        /// NLog
        /// </summary>
        public bool KeepFileOpen { get; set; }

        public Configuration()
        {
            Buffered = false;
            Shared = false;
            AutoFlush = !Buffered;
            KeepFileOpen = false;
        }

        public void Deconstruct(out bool Buffered, out bool Shared, out bool AutoFlush, out bool KeepFileOpen)
        {
            Buffered = this.Buffered;
            Shared = this.Shared;
            AutoFlush = this.AutoFlush;
            KeepFileOpen = this.KeepFileOpen;
        }
    }

    public static class LoggerBuilders
    {
        private const string AuditRepository = "AuditRepository";

        public static Serilog.Core.Logger BuildSerilogLogFactory(Configuration configuration = null)
        {
            var (Buffered, Shared, _, _) = configuration ?? new Configuration();
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

        public static NLog.LogFactory BuildNLogFactory(Configuration configuration = null)
        {
            var jsonLayout = new NLog.Layouts.JsonLayout
            {
                IncludeAllProperties = true,
                Attributes = {
                    new NLog.Layouts.JsonAttribute("@t", "${longdate}"),
                    new NLog.Layouts.JsonAttribute("@l", "${level:upperCase=true}"),
                    new NLog.Layouts.JsonAttribute("@mt", "${message:raw=true}"),
                }
            };

            var (_, Shared, AutoFlush, KeepFileOpen) = configuration ?? new Configuration(); ;
            var fileTarget = new NLog.Targets.FileTarget("audit-log")
            {
                FileName = "${currentdir}/nlog/audit-${date:format=yyyyMMddHHmm}-latest.log",

                AutoFlush = AutoFlush,
                ConcurrentWrites = Shared,
                KeepFileOpen = KeepFileOpen,

                ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Rolling,
                ArchiveAboveSize = 100_000_000,
                ArchiveFileName = "${currentdir}/nlog/audit-${date:format=yyyyMMddHHmm}-{###}.log",
                Layout = jsonLayout
            };

            var loggingConfiguration = new NLog.Config.LoggingConfiguration();

            loggingConfiguration.AddTarget(fileTarget);

            loggingConfiguration.AddRuleForOneLevel(NLog.LogLevel.Info, fileTarget);

            return new NLog.LogFactory(loggingConfiguration)
            {
                ThrowExceptions = true,
                ThrowConfigExceptions = true,
            };

        }
        public static string BuildLog4Net(Configuration configuration = null)
        {
            var (Buffered, _, _, _) = configuration ?? new Configuration();

            //var layout = new log4net.Layout.PatternLayout("%date{MMM/dd/yyyy HH:mm:ss,fff} [%thread] %-5level %logger %ndc – %message%newline");
            var layout = new log4net.Layout.SerializedLayout();
            layout.AddDecorator(new log4net.Layout.Decorators.StandardTypesDecorator());
            layout.AddDefault("");
            layout.AddRemove("message");
            layout.AddMember("messageobject");
            layout.ActivateOptions();


            var filter = new log4net.Filter.LevelMatchFilter();
            filter.LevelToMatch = log4net.Core.Level.All;
            filter.ActivateOptions();

            string instanceName = "Audit";

            var appender = new log4net.Appender.RollingFileAppender
            {
                File = $@"log4net\audit-{DateTime.Now.ToString("yyyyMMddHHmm")}-latest.log",
                ImmediateFlush = true,
                AppendToFile = true,
                RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite,
                DatePattern = "yyyyMMddhhmm",
                MaxFileSize = 100_000_000,
                LockingModel = new log4net.Appender.FileAppender.MinimalLock(),
                Name = $"{instanceName}Appender"
            };
            appender.AddFilter(filter);
            appender.Layout = layout;
            appender.ActivateOptions();



            var repository = log4net.Core.LoggerManager.CreateRepository(AuditRepository);

            log4net.Config.BasicConfigurator.Configure(repository, appender);


            return AuditRepository;

        }





    }
}
