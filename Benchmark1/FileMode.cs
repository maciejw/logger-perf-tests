using System;

namespace LoggingBenchmarks
{
    [Flags]
    public enum FileMode
    {
        None = 0,
        KeepFileOpen = 1,
        Buffered = 2,
        Shared = 4,
        KeepFileOpenBuffered = KeepFileOpen | Buffered,
        KeepFileOpenShared = KeepFileOpen | Shared,
    }
}
