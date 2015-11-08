using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VM
{
    class Parser
    {
        public Code Code { get; private set; }
        public Constants Constants { get; private set; }
        public int EntryPoint { get; private set; }

        private int pointer;

        string source;
        string[] tokens;
        public Parser(string source)
        {
            this.source = source;
            Code = new Code();
            Constants = new Constants();
            EntryPoint = 0;
            Init();
        }

        private void Init()
        {
            Code = new Code();
            Constants = new Constants();
            pointer = 0;
            tokens = source.Split(new char[] { ' ', ':', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            while (pointer < tokens.Length)
            {

                switch (tokens[pointer])
                {
                    case ModuleStructure.CONSTANTS:
                        pointer++;
                        ParseConstants();
                        break;
                    case ModuleStructure.CODE:
                        pointer++;
                        ParseCode();
                        break;
                    case ModuleStructure.ENTRYPOINT:
                        pointer++;
                        ParseEntryPoint();
                        break;

                }
            }
        }

        private void ParseConstants()
        {
            try
            {
                while (true)
                {
                    int id = Int32.Parse(tokens[pointer]);
                    pointer++;
                    string type = tokens[pointer];
                    pointer++;
                    string value = tokens[pointer];
                    pointer++;
                    while ((type == ConstantDataType.str) && (value[value.Length - 1] != '"'))
                    {
                        value += tokens[pointer];
                        pointer++;
                    }
                    Constants.AddConstant(id, ConstantValueFactory.Create(type, value));
                }
            }
            catch { }
        }

        private void ParseCode()
        {
            try
            {
                while (true)
                {
                    int id = Int32.Parse(tokens[pointer]);
                    pointer++;
                    string name = tokens[pointer];
                    pointer++;
                    int arg = Int32.Parse(tokens[pointer]);
                    pointer++;
                    CodeCommand command;
                    command.Name = name;
                    command.Arg = arg;
                    Code.AddCommand(command);
                }
            }
            catch { }
        }

        private void ParseEntryPoint()
        {
            try
            {
                EntryPoint = Int32.Parse(tokens[pointer]);
                pointer++;
            }
            catch { }
        }

    }
}
