using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    abstract class Variable
    {
        public object Value { get; protected set; }
        public abstract Function AsFunction();
        public abstract bool AsBoolean();
        public abstract Variable GetProperty(string name);
        public abstract void SetProperty(string name, Variable value);
        public abstract void SetValue(object val);


        public static Variable operator +(Variable v1, Variable v2)
        {
            if ((!(v1.Value is Function)) && (!(v2.Value is Function)))
            {
                double res1;
                double res2;
                bool isRes1 = false;
                bool isRes2 = false;
                isRes1 = double.TryParse(v1.Value.ToString(), out res1);
                isRes2 = double.TryParse(v2.Value.ToString(), out res2);
                if (isRes1 && isRes2)
                {
                    return new ObjectVariable(res1 + res2);
                }
                if (((v1.Value is Undefined) || (v1.Value is NaN) || (v1.Value is NaN) || (v2.Value is Undefined)))
                {
                    if (isRes1 || isRes2)
                    {
                        return new ObjectVariable(new NaN());
                    }
                    if (((v1.Value is Undefined) && (v2.Value is Undefined)) || ((v1.Value is NaN) && (v2.Value is NaN)) || ((v1.Value is Undefined) && (v2.Value is NaN)) || ((v1.Value is NaN) && (v2.Value is Undefined)))
                    {
                        return new ObjectVariable(new NaN());
                    }
                }
                if (isRes1 || isRes2)
                {
                    if (v1.Value is bool)
                    {
                        return bool.Parse(v1.Value.ToString()) ? new ObjectVariable(res2 + 1) : new ObjectVariable(res2 + 0);
                    }
                    if (v2.Value is bool)
                    {
                        return bool.Parse(v2.Value.ToString()) ? new ObjectVariable(res1 + 1) : new ObjectVariable(res1 + 0);
                    }
                }
            }
            return new ObjectVariable(v1.ToString() + v2.ToString());
        }

        public static Variable operator -(Variable v1, Variable v2)
        {
            double res1;
            double res2;
            if (double.TryParse(v1.Value.ToString(), out res1))
            {
                if (double.TryParse(v2.Value.ToString(), out res2))
                {
                    return new ObjectVariable(res1 - res2);
                }
            }
            return new ObjectVariable(new NaN());
        }

        public static Variable operator *(Variable v1, Variable v2)
        {
            double res1;
            double res2;
            if (double.TryParse(v1.Value.ToString(), out res1))
            {
                if (double.TryParse(v2.Value.ToString(), out res2))
                {
                    return new ObjectVariable(res1 * res2);
                }
            }
            return new ObjectVariable(new NaN());
        }

        public static Variable operator /(Variable v1, Variable v2)
        {
            double res1;
            double res2;
            if (double.TryParse(v1.Value.ToString(), out res1))
            {
                if (double.TryParse(v2.Value.ToString(), out res2))
                {
                    return new ObjectVariable(res1 / res2);
                }
            }
            return new ObjectVariable(new NaN());
        }

        public static bool operator >(Variable v1, Variable v2)
        {
            if (v1.Value is bool)
            {
                v1 = new ObjectVariable((bool)v1.Value ? 1 : 0);
            }
            if (v2.Value is bool)
            {
                v2 = new ObjectVariable((bool)v2.Value ? 1 : 0);
            }
            double res1;
            double res2;
            bool isRes1 = false;
            bool isRes2 = false;
            isRes1 = double.TryParse(v1.Value.ToString(), out res1);
            isRes2 = double.TryParse(v2.Value.ToString(), out res2);
            if ((isRes1) && (isRes2))
            {
                return res1 > res2;
            }
            return false;
        }

        public static bool operator <(Variable v1, Variable v2)
        {
            if (v1.Value is bool)
            {
                v1 = new ObjectVariable((bool)v1.Value ? 1 : 0);
            }
            if (v2.Value is bool)
            {
                v2 = new ObjectVariable((bool)v2.Value ? 1 : 0);
            }
            double res1;
            double res2;
            bool isRes1 = false;
            bool isRes2 = false;
            isRes1 = double.TryParse(v1.Value.ToString(), out res1);
            isRes2 = double.TryParse(v2.Value.ToString(), out res2);
            if ((isRes1) && (isRes2))
            {
                return res1 < res2;
            }
            return false;
        }

        public static bool operator >=(Variable v1, Variable v2)
        {
            if ((v1.Value is Undefined) || (v2.Value is Undefined) || (v1.Value is NaN) || (v2.Value is NaN))
            {
                return false;
            }
            if (v1.Value is bool)
            {
                v1 = new ObjectVariable((bool)v1.Value ? 1 : 0);
            }
            if (v2.Value is bool)
            {
                v2 = new ObjectVariable((bool)v2.Value ? 1 : 0);
            }
            if ((v1.Value.ToString() != NaN.Value) || (v2.Value.ToString() != NaN.Value))
            {
                double res1;
                double res2;
                if (double.TryParse(v1.Value.ToString(), out res1))
                {
                    if (double.TryParse(v2.Value.ToString(), out res2))
                    {
                        return res1 >= res2;
                    }
                }
            }
            return v1.Value.ToString().Equals(v2.Value.ToString());
        }

        public static bool operator <=(Variable v1, Variable v2)
        {
            if ((v1.Value is Undefined) || (v2.Value is Undefined) || (v1.Value is NaN) || (v2.Value is NaN))
            {
                return false;
            }
            if (v1.Value is bool)
            {
                v1 = new ObjectVariable((bool)v1.Value ? 1 : 0);
            }
            if (v2.Value is bool)
            {
                v2 = new ObjectVariable((bool)v2.Value ? 1 : 0);
            }
            if ((v1.Value.ToString() != NaN.Value) || (v2.Value.ToString() != NaN.Value))
            {
                double res1;
                double res2;
                if (double.TryParse(v1.Value.ToString(), out res1))
                {
                    if (double.TryParse(v2.Value.ToString(), out res2))
                    {
                        return res1 <= res2;
                    }
                }
            }
            return v1.Value.ToString().Equals(v2.Value.ToString());
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
