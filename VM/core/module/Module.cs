
namespace VM
{
    class Module
    {
        public Constants Constants { get; set; } 
        public Code Code { get; set; }
        public int EntryPoint { get; set; }
    }
}
