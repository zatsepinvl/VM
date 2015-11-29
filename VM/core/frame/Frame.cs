using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Frame
    {
        public Frame Parent { get; set; }
        public int Id { get; set; }
        public int EntryPoint { get; set; }
        public int ArgsCount { get; set; }

        public object Clone(int id, Frame parent)
        {
            return new Frame()
            {
                Parent = parent,
                Id = id,
                EntryPoint = EntryPoint,
                ArgsCount = ArgsCount
            };
        }
    }
}
