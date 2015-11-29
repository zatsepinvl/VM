using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    struct VariableIdent
    {
        public int FrameId { get; set; }
        public string VariableName { get; set; }
    }

    class Memory
    {
        private Dictionary<VariableIdent, Variable> variables = new Dictionary<VariableIdent, Variable>();
        private FrameStack frameStack = new FrameStack();

        public void PushFrame(Frame frame)
        {
            frameStack.Push(frame);
        }

        public Variable GetVariable(string variable)
        {
            Variable var = FindVariable(variable);
            if (var == null)
            {
                throw new MemoryException(variable + " is not defined");
            }
            return var;
        }

        public void SetVariableValue(string variable, Variable value)
        {
            Variable var = FindVariable(variable);
            if (var != null)
            {
                var.SetValue(value.Value);
            }
            else
            {
                VariableIdent ident = new VariableIdent()
                {
                    FrameId = frameStack.Peek().Id,
                    VariableName = variable
                };
                variables.Add(ident, value);
            }
        }

        public void InitVariable(string variable)
        {
            VariableIdent ident = new VariableIdent()
            {
                FrameId = frameStack.Peek().Id,
                VariableName = variable
            };
            if (!variables.ContainsKey(ident))
            {
                variables[ident] = new ObjectVariable(new Undefined());
            }
        }

        private Variable FindVariable(string variableName)
        {
            Frame currentFrame = frameStack.Peek();
            VariableIdent variableIdent = new VariableIdent()
            {
                FrameId = currentFrame.Id,
                VariableName = variableName
            };
            while (!(variables.ContainsKey(variableIdent)) && (currentFrame.Parent != null))
            {
                currentFrame = currentFrame.Parent;
                variableIdent.FrameId = currentFrame.Id;
            }
            if (variables.ContainsKey(variableIdent))
            {
                return variables[variableIdent];
            }
            return null;
        }

        public Frame PopFrame()
        {
            if (frameStack.Count > 0)
            {
                return frameStack.Pop();
            }
            else
            {
                return null;
            }
        }
        public Frame PeekFrame()
        {
            return frameStack.Peek();
        }

        public void ClearVariables()
        {
            variables.Clear();
        }
        public void ClearFrames()
        {
            frameStack.Clear();
        }
        public void ClearAll()
        {
            ClearVariables();
            ClearFrames();
        }
    }
}
