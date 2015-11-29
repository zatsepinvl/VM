using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class FrameStack
    {
        private Stack<Frame> frameStack = new Stack<Frame>();

        public int Count
        {
            get { return frameStack.Count; }
        }

        public Frame Peek()
        {
            if (frameStack.Count > 0)
            {
                return frameStack.Peek();
            }
            else
            {
                throw new MemoryException("frame stack is empty");
            }
        }

        public void Push(Frame frame)
        {
            frameStack.Push(frame);
        }

        public Frame Pop()
        {
            if (frameStack.Count > 0)
            {
                return frameStack.Pop();
            }
            else
            {
                throw new MemoryException("frame stack is empty");
            }
        }

        public void Clear()
        {
            frameStack.Clear();
        }
    }
}
