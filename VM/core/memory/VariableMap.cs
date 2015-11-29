using System.Collections.Generic;

namespace VM
{
    class VariableMap
    {
        private Dictionary<VariableIdent, int> variables = new Dictionary<VariableIdent, int>();

        public void AddVariable(VariableIdent ident, int id)
        {
            variables.Add(ident, id);
        }

        public int GetVariable(VariableIdent ident)
        {
            if (variables.ContainsKey(ident))
            {
                return variables[ident];
            }
            return -1;
        }
    }
}
