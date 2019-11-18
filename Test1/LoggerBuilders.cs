using System;
using Serilog;

namespace Test1
{
    public class Configuration
    {
        public bool Buffered { get; set; }
        public bool Shared { get; set; }
        public bool AutoFlush { get; set; }
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

        public static Serilog.Core.Logger BuildSerilogLogFactory(Configuration configuration = null )
        {
            configuration = configuration ?? new Configuration();

            var (Buffered, Shared, _, _) = configuration;
            return new Serilog.LoggerConfiguration()
               .WriteTo.File(
                new Serilog.Formatting.Compact.CompactJsonFormatter(),
                $"./serilog/{DateTime.Now.ToString("yyyyMMddHHmm")}-latest.log",
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

            configuration = configuration ?? new Configuration();

            var (_, Shared, AutoFlush, KeepFileOpen) = configuration;
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
    }
}
