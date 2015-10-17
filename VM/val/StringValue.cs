using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class StringValue : IValue
    {
        string value;

        public DataType DataType
        {
            get
            {
                return DataType.String;
            }
        }

        public bool AsBoolean()
        {
            throw new NotImplementedException();
        }

        public double AsNumber()
        {
            throw new NotImplementedException();
        }

        public IRuntimeContextInstance AsObject()
        {
            throw new NotImplementedException();
        }

        public string AsString()
        {
            return value;
        }

        public int CompareTo(IValue other)
        {
            return value.CompareTo(other.AsString());
        }

        public bool Equals(IValue other)
        {
            return value.Equals(other.AsString());
        }

        public void SetValue(object val)
        {
            value = (string)val;
        }
    }
}
