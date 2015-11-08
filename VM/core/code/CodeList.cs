using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    /// <summary>
    /// List of VM commands
    /// </summary>
    class CodeList
    {
        //General
        public const string PUSH_CONST = "PushConst";
        public const string PUSH_VAR = "PushVar";
        public const string LOAD_VAR = "LoadVar";
        public const string RETURN = "Return";

        //System
        public const string PRINT = "Print";

        //Math
        public const string ADD = "Add";
        public const string SUBT = "Subt";
        public const string MULT = "Mult";
        public const string DIV = "Div";
  
    }
}
