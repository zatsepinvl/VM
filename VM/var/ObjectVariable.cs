using System;
using System.Collections.Generic;


namespace VM
{
    class ObjectVariable : Variable
    {

        Dictionary<string, Variable> properties = new Dictionary<string, Variable>();

        public ObjectVariable() { }
        public ObjectVariable(object value)
        {
            Value = value;
        }

        public override void SetValue(object val)
        {
            Value = val;
        }

        public override Variable GetProperty(string name)
        {
            if (properties.ContainsKey(name))
            {
                return properties[name];
            }
            else
            {
                return new ObjectVariable(new Undefined());
            }
        }

        public override void SetProperty(string name, Variable value)
        {
            if (properties.ContainsKey(name))
            {
                properties[name] = value;
            }
            else
            {
                properties.Add(name, value);
            }
        }

        public override Function AsFunction()
        {
            return Value as Function;
        }

        public override bool AsBoolean()
        {
            string value = Value.ToString();
            if ((value.Equals(bool.FalseString)) || (value.Equals(NaN.Value)) || (value.Equals(Undefined.Value)) || (value.Equals("0")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
