using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class CodeManager
    {
        private Dictionary<string, Action<int>> commands = new Dictionary<string, Action<int>>();
        private CodeExecuter codeExecuter = new CodeExecuter();
        private Module module;

        public CodeManager()
        {
            Init();
        }


        private void Init()
        {
            commands.Add(CodeList.PUSH_VAR, codeExecuter.PushVar);
            commands.Add(CodeList.PUSH_CONST, codeExecuter.PushConst);
            commands.Add(CodeList.RETURN, codeExecuter.Return);
            commands.Add(CodeList.PRINT, codeExecuter.Print);
            commands.Add(CodeList.ADD, codeExecuter.Add);
            commands.Add(CodeList.DIV, codeExecuter.Div);
        }

        public void SetModule(Module module)
        {
            this.module = module;
            codeExecuter.Module = module;
        }

        public void ExecuteCode()
        {
            module.Code.Pointer = module.EntryPoint;
            while(true)
            {
                Execute(module.Code.CurrentCommand, module.Code.CurrentCommandArg);
            }
        }

        private void Execute(string commandName, int arg)
        {
            commands[commandName](arg);
        }

    }
}
