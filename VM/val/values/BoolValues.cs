using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class BoolValues : IValue
    {
        private bool value;
        public DataType DataType
        {
            get
            {
                return DataType.Bool;
            }
        }

        public bool AsBoolean()
        {
            return value;
        }

        public double AsNumber()
        {
            if (value)
            {
                return 1;
            }
            return 0;
        }

        public IRuntimeContextInstance AsObject()
        {
            throw new NotImplementedException();
        }

        public string AsString()
        {
            return AsNumber().ToString();
        }

        public int CompareTo(IValue other)
        {
            if(other.DataType==DataType)
            {
                return AsNumber().CompareTo(other.AsNumber());
            }
            return -1;
        }

        public bool Equals(IValue other)
        {
           if(other.DataType==DataType)
            {
                return AsNumber().Equals(other.AsNumber());
            }
            return false;
        }

        public void SetValue(object val)
        {
            value = (bool)val;
        }
    }
}
