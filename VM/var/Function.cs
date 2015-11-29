
using System;

namespace VM
{
    class Function
    {
        public int EntryPoint { get; set; }
        public int ArgsNumber { get; set; }

        public override string ToString()
        {
            return "function entry_point: " + EntryPoint.ToString() + ", args_count: " + ArgsNumber.ToString();
        }
    }
}
