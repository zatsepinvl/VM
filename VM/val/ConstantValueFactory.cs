using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class ConstantValueFactory
    {
        public static IValue Create(string type, string value)
        {
            IValue val;
            switch (type)
            {
                case ConstantDataType.number:
                    val = new NumberValue();
                    val.SetValue(double.Parse(value));
                    break;
                case ConstantDataType.boolean:
                    val = new BoolValues();
                    val.SetValue(bool.Parse(value));
                    break;
                case ConstantDataType.str:
                    val = new StringValue();
                    if (value.Length > 0)
                    {
                        val.SetValue(value.Substring(1, value.Length - 2));
                    }
                    else
                    {
                        val.SetValue("");
                    }
                    break;
                default:
                    val = new StringValue();
                    val.SetValue(value);
                    break;

            }
            return val;
        }
    }
}
