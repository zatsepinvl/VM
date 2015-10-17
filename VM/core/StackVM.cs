using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    static class StackVM
    {
        private static Stack<IValue> stack = new Stack<IValue>();

        public static void Push(IValue arg)
        {
            stack.Push(arg);
        }

        public static IValue Pop()
        {
            return stack.Pop();
        }

        public static IValue[] GetCurrentStackState()
        {
            return stack.ToArray();
        }

    }
}
