using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VM
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = new Core();
            FileStream file = new FileStream(args[0], FileMode.Open);
            StreamReader reader = new StreamReader(file);        
            core.Execute(reader.ReadToEnd());
            Utils.PrintStack();
            Console.ReadKey();
        }
    }
}
