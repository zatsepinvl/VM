using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Context
    {
        public int id;
        private Context parent;
        private List<IValue> variables = new List<IValue>();
        private List<Context> innerContexts = new List<Context>();

        public IValue getVariable(int id)
        {
            return variables[id];
        }

        public int setVariable(IValue variable)
        {
            variables.Add(variable);
            return variables.Count - 1;
        }
    }
}
