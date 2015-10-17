using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Core
    {
        private CommandExecuter executer;
        private CodeList parser;

        public Core()
        {
            parser = CodeList.Instance;
            executer = new CommandExecuter();
        }
        public void Execute(string[] s)
        {
            ParseString(s);
            ExecuteCode();
        }

        private void ParseString(string[] s)
        {
            parser.Init(s);
        }

        private void ExecuteCode()
        {
            try
            {
                MainCommandLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void MainCommandLoop()
        {
            while (true)
            {
                executer.Call(parser.CurrentCommand, parser.CurrentCommandArg);
                //Utils.PrintStack();
            }
        }
    }
}
