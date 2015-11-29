using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Constants
    {
        private Dictionary<int, Variable> constants = new Dictionary<int, Variable>();

        public Variable GetConstant(int id)
        {
            return constants[id];
        }

        public void AddConstant(int id, Variable value)
        {
            if (constants.ContainsKey(id))
            {
                constants[id] = value;
            }
            else
            {
                constants.Add(id, value);
            }
        }
    }
}
