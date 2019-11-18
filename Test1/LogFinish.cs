using System;
using System.Diagnostics;
using Xunit;

namespace Test1
{
    public delegate void LogFinish(string message, long elapsed, int count);
}
