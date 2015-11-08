using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class ObjectValue : IValue
    {
        object value;

        public DataType DataType
        {
            get
            {
                return DataType.Object;
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
            return null;
        }

        public string AsString()
        {
            return value.ToString();
        }

        public int CompareTo(IValue other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IValue other)
        {
            return value.Equals(other);
        }

        public void SetValue(object val)
        {
            value = val;
        }
    }
}
