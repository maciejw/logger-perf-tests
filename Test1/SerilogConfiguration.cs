namespace LoggingTests
{

    public class SerilogConfiguration
    {
        public bool Buffered { get; set; }

        public bool Shared { get; set; }

        public SerilogConfiguration()
        {
            Buffered = false;
            Shared = false;
        }

        public void Deconstruct(out bool Buffered, out bool Shared)
        {
            Buffered = this.Buffered;
            Shared = this.Shared;
        }
    }
}
