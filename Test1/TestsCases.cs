using System.Diagnostics;

namespace LoggingTests
{
    public static class TestsCases
    {
        public static void TestCase1(LogEntry logEntry, LogFinish logFinish)
        {
            SomeData data = new SomeData
            {
                MyProperty6 = new SomeData()
            };

            Stopwatch sw = Stopwatch.StartNew();

            const int count = 1;
            for (int i = 0; i < count; i++)
            {
                logEntry("My data '{i}' {@data}", i, data);
            }

            logFinish("Finished '{count}' iterations in '{elapsedMilliseconds} ms'", sw.ElapsedMilliseconds, count);
        }
    }
}
