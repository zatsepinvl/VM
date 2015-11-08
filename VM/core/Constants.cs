using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class Constants
    {
        private Dictionary<int, IValue> constants = new Dictionary<int, IValue>();

        public IValue GetConstant(int id)
        {
            return constants[id];
        }

        public void AddConstant(int id, IValue value)
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
