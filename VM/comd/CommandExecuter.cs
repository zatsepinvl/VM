using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class CommandExecuter
    {
        private Dictionary<string, Action<int>> commands = new Dictionary<string, Action<int>>();
        private CommandList commandList = new CommandList();

        public CommandExecuter()
        {
            Init();
        }

        private void Init()
        {
            commands.Add(CommandList.ADD, commandList.Add);
            commands.Add(CommandList.DIV, commandList.Div);
            commands.Add(CommandList.PUSH_VAR, commandList.PushVar);
            commands.Add(CommandList.PRINT, commandList.Print);
        }

        public void Call(string commandName, int arg)
        {
            commands[commandName](arg);
        }

    }
}
