using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class CodeExecuter
    {
        public Module Module { get; set;}

        public void PushVar(int arg)
        {
            StackVM.Push(ValueFactory.Create(arg));
            GoNext();
        }

        public void PushConst(int arg)
        {
            StackVM.Push(Module.Constants.GetConstant(arg));
            GoNext();
        }
        
        public void Return(int arg)
        {
            GoNext();
        }

        public void Add(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();

            if (v1.DataType == DataType.String)
            {
                StackVM.Push(ValueFactory.Create(v2.AsString() + v1.AsString()));
            }
            else
            {
                StackVM.Push(ValueFactory.Create(v1.AsNumber() + v2.AsNumber()));
            }
            GoNext();
        }

        public void Dif(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();
            StackVM.Push(ValueFactory.Create(v1.AsNumber() - v2.AsNumber()));
            GoNext();
        }

        public void Mult(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();
            StackVM.Push(ValueFactory.Create(v1.AsNumber() * v2.AsNumber()));
            GoNext();
        }

        public void Div(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();
            StackVM.Push(ValueFactory.Create(v1.AsNumber() / v2.AsNumber()));
            GoNext();
        }

        public void Print(int arg)
        {
            Console.WriteLine(StackVM.Peek().AsString());
            GoNext();
        }

        private void Go(int pointer)
        {
            Module.Code.Pointer = pointer;
        }

        private void GoNext()
        {
            Module.Code.Pointer++;
        }
    }
}
