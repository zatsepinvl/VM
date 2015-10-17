using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class ValueFactory
    {
        public static IValue Create(object val)
        {
            IValue value;
            if ((val.GetType() == typeof(double)) || (val.GetType() == typeof(int)))
            {
                value = new NumberValue();
                value.SetValue(Convert.ToDouble(val));
            }
            else if (val.GetType() == typeof(string))
            {
                value = new StringValue();
                value.SetValue(val);
            }
            else
            {
                value = new ObjectValue();
            }
            return value;
        }
    }
}
