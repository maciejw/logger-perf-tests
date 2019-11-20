using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using LoggingTests;
using System.Collections.Generic;
using System.Linq;
using static LoggingBenchmarks.FileMode;

namespace LoggingBenchmarks
{

    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig(Runtime[] runtimes = null, NuGetReference[] nlogs = null, NuGetReference[] serilogs = null, NuGetReference[] log4nets = null)
        {
            runtimes = runtimes ?? new Runtime[] { CoreRuntime.Core21, CoreRuntime.Core30, ClrRuntime.Net461, ClrRuntime.Net48 };
            nlogs = nlogs ?? new[] { new NuGetReference("NLog", "4.5.11"), };
            serilogs = log4nets ?? new[] { new NuGetReference("Serilog", "2.9.0"), };
            log4nets = log4nets ?? new[] { new NuGetReference("log4net", "2.0.8"), };

            var packageSets =
                from nlog in nlogs
                from serilog in serilogs
                from log4net in log4nets
                select new NuGetReferenceList { nlog, serilog, log4net };

            var jobs =
                from runtime in runtimes
                from packageSet in packageSets
                select Job.Default
                    .With(runtime)
                    .WithNuGet(packageSet);

            Add(DefaultConfig.Instance);
            Add(jobs.ToArray());
        }
    }
}
