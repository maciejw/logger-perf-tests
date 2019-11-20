namespace LoggingTests
{

    public class NLogConfiguration
    {
        public bool Shared { get; set; }

        public bool Buffered { get; set; }

        public bool KeepFileOpen { get; set; }

        public NLogConfiguration()
        {
            Shared = false;
            Buffered = false;
            KeepFileOpen = false;
        }

        public void Deconstruct(out bool Buffered, out bool KeepFileOpen, out bool Shared)
        {
            Shared = this.Shared;
            Buffered = this.Buffered;
            KeepFileOpen = this.KeepFileOpen;
        }
    }
}
