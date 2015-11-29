
namespace VM
{


    class ModuleFactory
    {
        public static Module Create(string source)
        {
            Module module = new Module();
            Parser parser = new Parser(source);
            module.Code = parser.Code;
            module.InitialFrame = new Frame()
            {
                Id = 0,
                ArgsCount = 0,
                EntryPoint = 0,
                Parent = null
            };
            return module;
        }
    }
}
