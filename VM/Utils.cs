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
            Console.WriteLine("Stack:");
            foreach(Variable i in StackVM.GetCurrentStackState())
            {
                Console.WriteLine("| " + i.ToString() + " |");
            }
            Console.WriteLine("--------");
        }
    }
}
