using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class Core
    {
        private ModuleManager moduleManager;

        public void Execute(string s)
        {
            try
            {
                moduleManager = new ModuleManager(ModuleFactory.Create(s));
                moduleManager.OnCodeExecuted += ModuleManagerOnCodeExecuted;
                ExecuteCode();
            }
            catch (VMException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ModuleManagerOnCodeExecuted()
        {
            Console.WriteLine("Executed");
        }

        private void ExecuteCode()
        {
            moduleManager.ExecuteCode();
        }
    }
}
