using System;

namespace VM
{
    class CodeExecuter
    {
        public Module Module { get; set; }
        public Memory Memory { get; set; }

        public CodeExecuter(Module module, Memory memory)
        {
            this.Module = module;
            this.Memory = memory;
        }

        protected void Init(object arg)
        {
            CheckIsArgVariable(arg);
            Memory.InitVariable(arg.ToString());
            GoNext();
        }

        protected void Push(object arg)
        {
            double res;
            if (arg.ToString()[0] == '"')
            {
                string value = arg.ToString().Substring(1, arg.ToString().Length - 2);
                StackVM.Push(new ObjectVariable(value));
            }
            else if (arg.ToString() == "undefined")
            {
                StackVM.Push(new ObjectVariable(new Undefined()));
            }
            else if (arg.ToString() == "NaN")
            {
                StackVM.Push(new ObjectVariable(new NaN()));
            }
            else  if (double.TryParse(arg.ToString(), out res))
            {
                StackVM.Push(new ObjectVariable(res));
            }
            else if (arg.ToString() == "true")
            {
                StackVM.Push(new ObjectVariable(true));
            }
            else if (arg.ToString() == "false")
            {
                StackVM.Push(new ObjectVariable(false));
            }
            else
            {
                StackVM.Push(Memory.GetVariable(arg.ToString()));
            }
            GoNext();
        }

        protected void Load(object arg)
        {
            CheckIsArgVariable(arg);
            Memory.SetVariableValue(arg.ToString(), StackVM.Pop());
            GoNext();
        }

        protected void Jmp(object arg)
        {
            int point;
            try
            {
                point = Int32.Parse(arg.ToString());
            }
            catch
            {
                throw new CodeException(Module.Code.Pointer.ToString() + ": invalid arg in Jmp; found: " + arg.ToString() + ", expected integer");
            }
            Module.Code.Pointer = point;
        }

        protected void JmpFalse(object arg)
        {
            int point;
            try
            {
                point = Int32.Parse(arg.ToString());
            }
            catch
            {
                throw new CodeException(Module.Code.Pointer.ToString() + ": invalid arg in JmpFalse; found: " + arg.ToString() + ", expected integer");
            }
            if (!StackVM.Pop().AsBoolean())
            {
                Go(point);
            }
            else
            {
                GoNext();
            }
        }

        protected void JmpTrue(object arg)
        {
            int point;
            try
            {
                point = Int32.Parse(arg.ToString());
            }
            catch
            {
                throw new CodeException(Module.Code.Pointer.ToString() + ": invalid arg in JmpFalse; found: " + arg.ToString() + ", expected integer");
            }
            if (StackVM.Pop().AsBoolean())
            {
                Go(point);
            }
            else
            {
                GoNext();
            }
        }

        protected void Call(object arg)
        {
            Frame frame = new Frame();
            frame.Parent = Memory.PeekFrame();
            frame.Id = frame.Parent.Id + 1;
            frame.Parent.EntryPoint = Module.Code.Pointer;
            Function function = Memory.GetVariable(arg.ToString()).AsFunction();
            int argsCount = Int32.Parse(StackVM.Pop().Value.ToString());
            for (int i = 0; i < argsCount - function.ArgsNumber; i++)
            {
                StackVM.Pop();
            }
            if (function == null)
            {
                throw new CodeException(Module.Code.Pointer.ToString() + ": " + arg.ToString() + " is not a function");
            }
            Memory.PushFrame(frame);
            Go(function.EntryPoint);
        }

        protected void Return(object arg)
        {
            Frame frame = Memory.PopFrame();
            if ((frame != null) && (frame.Parent != null))
            {
                Module.Code.Pointer = frame.Parent.EntryPoint;
            }
            else
            {
                throw new CodeException("Executed");
            }
            GoNext();
        }

        protected void Add(object arg)
        {
            Variable v1 = StackVM.Pop();
            Variable v2 = StackVM.Pop();
            StackVM.Push(v2 + v1);
            GoNext();
        }

        protected void Subt(object arg)
        {
            Variable v1 = StackVM.Pop();
            Variable v2 = StackVM.Pop();
            StackVM.Push(v2 - v1);
            GoNext();
        }

        protected void Mult(object arg)
        {
            Variable v1 = StackVM.Pop();
            Variable v2 = StackVM.Pop();
            StackVM.Push(v2 * v1);
            GoNext();
        }

        protected void Div(object arg)
        {
            Variable v1 = StackVM.Pop();
            Variable v2 = StackVM.Pop();
            StackVM.Push(v2 / v1);
            GoNext();
        }
        protected void Greater(object arg)
        {
            StackVM.Push(new ObjectVariable(StackVM.Pop() < StackVM.Pop()));
            GoNext();
        }
        protected void GreaterEq(object arg)
        {
            StackVM.Push(new ObjectVariable(StackVM.Pop() <= StackVM.Pop()));
            GoNext();
        }
        protected void Less(object arg)
        {
            StackVM.Push(new ObjectVariable(StackVM.Pop() > StackVM.Pop()));
            GoNext();
        }
        protected void LessEq(object arg)
        {
            StackVM.Push(new ObjectVariable(StackVM.Pop() >= StackVM.Pop()));
            GoNext();
        }
        protected void PushFunc(object arg)
        {
            try
            {
                ObjectVariable var = new ObjectVariable(new Function() { EntryPoint = Module.Code.Pointer + 1, ArgsNumber = Int32.Parse(arg.ToString()) });
                StackVM.Push(var);
                GoUntilReturn();
            }
            catch (FormatException ex)
            {
                throw new CodeException(Module.Code.Pointer.ToString() + ": invalid arg in PushFunc; found: " + arg.ToString() + ", expected integer");
            }
        }

        protected void PushArgCount(object arg)
        {
            try
            {
                int argsCount = Int32.Parse(arg.ToString());
                StackVM.Push(new ObjectVariable(argsCount));
                GoNext();
            }
            catch (FormatException ex)
            {
                throw new CodeException(Module.Code.Pointer.ToString() + ": invalid arg in PushArgCount; found: " + arg.ToString() + ", expected integer");
            }
        }
        protected void Print(object arg)
        {
            Console.WriteLine(Memory.GetVariable(arg.ToString()).Value.ToString());
            GoNext();
        }

        protected void GoUntilReturn()
        {
            while (Module.Code.CurrentCommand != CodeList.RETURN)
            {
                Module.Code.Pointer++;
            }
            GoNext();
        }

        protected void Go(int pointer)
        {
            Module.Code.Pointer = pointer;
        }

        protected void GoNext()
        {
            Module.Code.Pointer++;
        }


        protected void CheckIsArgVariable(object arg)
        {
            if ((arg.ToString()[0] == '"') || (char.IsDigit(arg.ToString()[0])))
            {
                throw new CodeException((Module.Code.Pointer + 1).ToString() + " : missing variable name");
            }
        }
    }

}
