using System;
using System.Diagnostics;
using Xunit;

namespace Test1
{
    public delegate void LogEntry(string message, int i, SomeData data);
}
