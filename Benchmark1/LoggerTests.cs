using Xunit;

namespace LoggingTests
{
    public abstract class LoggerTests
    {
        protected abstract LogEntry LogEntry { get; }
        protected abstract LogFinish LogFinish { get; }

        [Fact]
        public virtual void TestCase1()
        {
            TestsCases.TestCase1(LogEntry, LogFinish);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(16)]
        public virtual void TestCase2(int threadCount)
        {
            TestsCases.TestCase2(threadCount, LogEntry, LogFinish);
        }
    }
}
