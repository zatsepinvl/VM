using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class CodeParser
    {
        protected Dictionary<string, int> code = new Dictionary<string, int>();

        public string CurrentCommand { get; protected set; }
        public int CurrentCommandArg { get; protected set; }

        protected int pointer;

        public int Pointer
        {
            get { return pointer; }
            set
            {
                if (pointer > 0 && pointer < code.Count)
                {
                    pointer = value;
                    CurrentCommand = code.Keys.ElementAt(pointer);
                    CurrentCommandArg = code[CurrentCommand];
                }
            }
        }

        public CodeParser(string[] strs)
        {
            Parse(strs);
        }

        private  void Parse(string[] strs)
        {
            char[] separators = new char[] { ' ' };
            foreach (string s in strs)
            {
                string[] x = s.Split(separators);
                code.Add(x[1], Int32.Parse(x[2]));
            }

        }

        public void Next()
        {
            if (pointer < code.Keys.Count - 1)
            {
                Pointer++;
            }
        }


    }
}
