namespace LoggingTests
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            using (SerilogTests tests = new SerilogTests())
            {
                tests.TestCase1();
            }
            using (NLogTests tests = new NLogTests())
            {
                tests.TestCase1();
            }
            using (Log4NetTests tests = new Log4NetTests())
            {
                tests.TestCase1();
            }
        }
    }
}
