
namespace VM
{


    class ModuleFactory
    {
        public static Module Create(string source)
        {
            Module module = new Module();
            Parser parser = new Parser(source);
            module.Constants = parser.Constants;
            module.Code = parser.Code;
            module.EntryPoint = parser.EntryPoint;
            return module;
        }
    }
}
