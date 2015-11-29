
namespace VM
{
    /// <summary>
    /// List of VM commands
    /// </summary>
    class CodeList
    {
        //General
        public const string INIT = "Init";
        public const string PUSH = "Push";
        public const string LOAD = "Load";
        public const string PUSH_FUNC = "PushFunc";
        public const string CALL = "Call";
        public const string RETURN = "Return";
        public const string JMP = "Jmp";
        public const string PUSH_ARG_COUNT = "PushArgCount";

        //System
        public const string PRINT = "Print";

        //Math
        public const string ADD = "Add";
        public const string SUBT = "Subt";
        public const string MULT = "Mult";
        public const string DIV = "Div";

        //Boolean
        public const string GREATER = "Greater";
        public const string GREATER_EQ = "GreaterEq";
        public const string LESS = "Less";
        public const string LESS_EQ = "LessEq";
        public const string EQUAL = "Equal";
        public const string NOT_EQUAL = "NotEqual";
        public const string STRICT_EQUAL = "StrictEqual";
        public const string NOT_STRICT_EQUAL = "NotStrictEqual";
        public const string JMP_FALSE= "JmpFalse";
        public const string JMP_TRUE = "JmpTrue";
    }
}
