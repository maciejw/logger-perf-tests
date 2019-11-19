namespace LoggingTests
{
    public class Log4NetConfiguration
    {
        public bool Buffered { get; set; }
        public bool KeepFileOpen { get; set; }
        public string InstanceName { get; set; }
        public bool Shared { get; set; }

        public Log4NetConfiguration()
        {
            Buffered = false;
            KeepFileOpen = false;
            InstanceName = "Audit";
        }

        public void Deconstruct(out string InstanceName, out bool Buffered, out bool KeepFileOpen, out bool Shared)
        {
            KeepFileOpen = this.KeepFileOpen;
            Buffered = this.Buffered;
            InstanceName = this.InstanceName;
            Shared = this.Shared;
        }
    }
}
