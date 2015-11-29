using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class CodeManager : CodeExecuter
    {
        private Dictionary<string, Action<object>> commands = new Dictionary<string, Action<object>>();
        private bool working;
        public CodeManager(Module module, Memory memory) : base(module, memory)
        {
            Init();
            module.Code.OnExecuted += CodeOnExecuted;
        }

        private void CodeOnExecuted()
        {
            working = false;
        }

        private void Init()
        {
            commands.Add(CodeList.INIT, Init);
            commands.Add(CodeList.PUSH, Push);
            commands.Add(CodeList.PUSH_FUNC, PushFunc);
            commands.Add(CodeList.CALL, Call);
            commands.Add(CodeList.LOAD, Load);
            commands.Add(CodeList.JMP, Jmp);
            commands.Add(CodeList.RETURN, Return);
            commands.Add(CodeList.PRINT, Print);
            commands.Add(CodeList.PUSH_ARG_COUNT, PushArgCount);

            //Math
            commands.Add(CodeList.ADD, Add);
            commands.Add(CodeList.DIV, Div);
            commands.Add(CodeList.SUBT, Subt);
            commands.Add(CodeList.MULT, Mult);

            //Boolean
            commands.Add(CodeList.GREATER, Greater);
            commands.Add(CodeList.GREATER_EQ, GreaterEq);
            commands.Add(CodeList.LESS, Less);
            commands.Add(CodeList.LESS_EQ, LessEq);
            commands.Add(CodeList.JMP_TRUE, JmpTrue);
            commands.Add(CodeList.JMP_FALSE, JmpFalse);

        }

        public void ExecuteCode()
        {
            working = true;
            while (working)
            {
                Execute(Module.Code.CurrentCommand, Module.Code.CurrentCommandArg);
                
            }
        }

        private void Execute(string commandName, object arg)
        {
            if (commands.ContainsKey(commandName))
            {
                //Console.WriteLine(commandName);
                commands[commandName](arg);
            }
            else
            {
                throw new CodeException((Module.Code.Pointer + 1).ToString() + ": unknown command " + commandName);
            }

        }

    }
}
