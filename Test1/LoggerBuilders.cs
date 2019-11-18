using System;
using Serilog;

namespace Test1
{
    internal static class LoggerBuilders {
        private const bool Buffered = false;
        private const bool Shared = false;
        private const bool AutoFlash = !Buffered;
        private const bool KeepFileOpen = true;

        public static Serilog.Core.Logger BuildSerilogLogFactory()
        {
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

        public static NLog.LogFactory BuildNLogFactory()
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

            var fileTarget = new NLog.Targets.FileTarget("audit-log")
            {
                FileName = "${currentdir}/nlog/audit-${date:format=yyyyMMddHHmm}-latest.log",

                AutoFlush = AutoFlash,
                ConcurrentWrites = Shared,
                KeepFileOpen = KeepFileOpen,

                ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Rolling,
                ArchiveAboveSize = 100_000_000,
                ArchiveFileName = "${currentdir}/nlog/audit-${date:format=yyyyMMddHHmm}-{###}.log",
                Layout = jsonLayout
            };

            var configuration = new NLog.Config.LoggingConfiguration();

            configuration.AddTarget(fileTarget);

            configuration.AddRuleForOneLevel(NLog.LogLevel.Info, fileTarget);

            return new NLog.LogFactory(configuration)
            {
                ThrowExceptions = true,
                ThrowConfigExceptions = true,
            };
        }
    }
}
