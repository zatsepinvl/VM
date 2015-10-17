using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class CommandsList
    {
        public const int CommandCount = 1;

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
        }

        public void Div(int arg)
        {
            IValue v1 = StackVM.Pop();
            IValue v2 = StackVM.Pop();
            StackVM.Push(ValueFactory.Create(v1.AsNumber() - v2.AsNumber()));
        }
    }
}
