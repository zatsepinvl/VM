using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    struct CodeCommand
    {
        public string Name;
        public int Arg;
    }

    class CodeList : Singleton<CodeList>
    {
        public const string END_OF_CODE = "Executed.";
        protected List<CodeCommand> code = new List<CodeCommand>();

        public string CurrentCommand { get; protected set; }
        public int CurrentCommandArg { get; protected set; }

        protected int pointer;

        public int CommandCount { get { return code.Count; } }
        public int Pointer
        {
            get { return pointer; }
            set
            {
                if (value >= 0 && value < code.Count)
                {
                    pointer = value;
                    CurrentCommand = code[pointer].Name;
                    CurrentCommandArg = code[pointer].Arg;
                }
                else
                {
                    throw new Exception(END_OF_CODE);
                }
            }
        }

        protected CodeList() { }
        public void Init(string[] strs)
        {
            code = new List<CodeCommand>();
            Parse(strs);
        }

        private void Parse(string[] strs)
        {
            char[] separators = new char[] { ' ' };
            foreach (string s in strs)
            {
                string[] x = s.Split(separators);
                code.Add(new CodeCommand() { Name = x[1], Arg = Int32.Parse(x[2]) });
            }
            if (code.Count > 0)
            {
                Pointer = 0;
            }
        }
    }
}
