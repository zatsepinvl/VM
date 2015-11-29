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
        private List<Variable> variables = new List<Variable>();
        private List<Context> innerContexts = new List<Context>();

        public Variable getVariable(int id)
        {
            return variables[id];
        }

        public int setVariable(Variable variable)
        {
            variables.Add(variable);
            return variables.Count - 1;
        }
    }
}
