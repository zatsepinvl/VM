using System;

namespace VM
{
    interface IValue : IComparable<IValue>, IEquatable<IValue>
    {
        DataType DataType { get; }

        double AsNumber();
        bool AsBoolean();
        string AsString();
        IRuntimeContextInstance AsObject();

        void SetValue(object val);

    }
}
