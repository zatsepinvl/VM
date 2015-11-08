using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class ContextStack:Singleton<ContextStack>
    {
        private Stack<Context> contexts = new Stack<Context>();

        protected ContextStack() { }
        public Context Peek()
        {
            return contexts.Peek();
        }

        public void Push(Context context)
        {
            contexts.Push(context);
        }

        public Context Pop()
        {
            return contexts.Pop();
        }
    }
}
