using System;

namespace VM
{
    class ModuleManager
    {
        public event Action OnCodeExecuted;
        protected Module module;
        protected CodeManager codeManager;
        protected Memory memory;

        public ModuleManager(Module module)
        {
            this.module = module;
            memory = new Memory();
            codeManager = new CodeManager(module, memory);
            memory.PushFrame(module.InitialFrame);
            module.Code.OnExecuted += CodeOnExecuted;
        }

        public void ExecuteCode()
        {
            module.Code.Pointer = module.InitialFrame.EntryPoint;
            codeManager.ExecuteCode();
        }

        private void CodeOnExecuted()
        {
            if (OnCodeExecuted != null)
            {
                OnCodeExecuted();
            }
        }
    }
}
