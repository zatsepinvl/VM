using System;

namespace VM
{
    class VMException : Exception
    {
        private static string PREFIX = "VM: ";
        public VMException(string message) : base(message) { }
    }
}
