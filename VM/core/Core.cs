using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Core
    {
        private CodeManager codeManager;

        public Core()
        {
            codeManager = new CodeManager();
        }
        public void Execute(string s)
        {
            codeManager.SetModule(ModuleFactory.Create(s));
            ExecuteCode();
        }

        private void ExecuteCode()
        {
            try
            {
                codeManager.ExecuteCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
