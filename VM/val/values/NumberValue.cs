using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class NumberValue : IValue
    {
        double value;

        public DataType DataType
        {
            get
            {
                return DataType.Number;
            }
        }

        public bool AsBoolean()
        {
            throw new NotImplementedException();
        }

        public double AsNumber()
        {
            return value;
        }

        public IRuntimeContextInstance AsObject()
        {
            throw new NotImplementedException();
        }

        public string AsString()
        {
            return value.ToString();
        }

        public int CompareTo(IValue other)
        {
            return value.CompareTo(other.AsNumber());
        }

        public bool Equals(IValue other)
        {
            return value.Equals(other.AsNumber());
        }

        public void SetValue(object val)
        {
            value = (double)val;
        }
    }
}
