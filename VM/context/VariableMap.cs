using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    struct VariableMapItem
    {
        public int ContextId { get; set; }
        public int VatiableId { get; set; }
    }

    class VariableMap:Singleton<VariableMap>
    {
        List<VariableMapItem> variables = new List<VariableMapItem>();

        protected VariableMap() { }

        public void AddVariable()
        {
        }
    }
}
