using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
   static class Utils
    {
        public static void PrintStack()
        {
            foreach(IValue i in StackVM.GetCurrentStackState())
            {
                Console.WriteLine("| " + i.AsString() + " |");
                Console.WriteLine("__________");
            }
        }
    }
}
