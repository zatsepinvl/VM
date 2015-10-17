using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Core
    {
        private CommandsList commands;
        private CodeParser parser;

        public Core()
        {
            commands = new CommandsList();
        }
        public void Execute(string[] s)
        {
            ParseString(s);
            ExecuteCode();
        }

        private void ParseString(string[] s)
        {
            parser = new CodeParser();
        }

        private void ExecuteCode()
        {
            while (true)
            {
                try
                {
                    MainCommandLoop();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void MainCommandLoop()
        {

        }
    }
}
