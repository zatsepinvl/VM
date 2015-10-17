using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class CommandList
    {
        public const string ADD = "Add";
        public const string DIV = "Div";
        public const string PUSH_VAR = "PushVar";
        public const string LOAD_VAR = "LoadVar";
        public const string PRINT = "Print";
        public const int CommandCount = 2;

        public void PushVar(int arg)
        {
            StackVM.Push(ValueFactory.Create(arg));
            GoNext();
        }
        public void Add(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();

            if (v1.DataType == DataType.String)
            {
                StackVM.Push(ValueFactory.Create(v1.AsString() + v2.AsString()));
            }
            else
            {
                StackVM.Push(ValueFactory.Create(v1.AsNumber() + v2.AsNumber()));
            }
            GoNext();
        }
        public void Div(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();
            StackVM.Push(ValueFactory.Create(v1.AsNumber() - v2.AsNumber()));
            GoNext();
        }
        public void Print(int arg)
        {
            Console.WriteLine(StackVM.Peek().AsString());
            GoNext();
        }

        private void Go(int pointer)
        {
            CodeList.Instance.Pointer = pointer;
        }
        private void GoNext()
        {
            CodeList.Instance.Pointer++;
        }
    }
}
