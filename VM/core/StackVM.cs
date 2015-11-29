using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    static class StackVM
    {
        private static Stack<Variable> stack = new Stack<Variable>();

        public static void Push(Variable arg)
        {
            stack.Push(arg);
        }

        public static Variable Pop()
        {
            if (stack.Count > 0)
            {
                return stack.Pop();
            }
            else
            {
                throw new MemoryException("stack is empty");
            }
        }

        public static Variable Peek()
        {
            return stack.Peek();
        }

        public static Variable[] GetCurrentStackState()
        {
            return stack.ToArray();
        }



    }
}
