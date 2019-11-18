using System;
using System.Diagnostics;
using Xunit;

namespace Test1
{
    public class SomeData
    {
        public SomeData()
        {
            MyProperty1 = 1;
            MyProperty2 = 1.4;
            MyProperty3 = DateTime.Now;
            MyProperty4 = true;
            MyProperty5 = "my value";
        }

        public int MyProperty1 { get; set; }
        public double MyProperty2 { get; set; }
        public DateTime MyProperty3 { get; set; }
        public bool MyProperty4 { get; set; }
        public string MyProperty5 { get; set; }
        public SomeData MyProperty6 { get; set; }
    }
}
