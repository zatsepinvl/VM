using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Frames
    {
        private Dictionary<int, Frame> frames = new Dictionary<int, Frame>();

        public void AddFrame(Frame frame)
        {
            frames.Add(frame.Id, frame);
        }

        public Frame GetFram(int id)
        {
            return frames[id];
        }

        public Frame CloneFrame(int id)
        {
            return new Frame();
        }
    }
}
