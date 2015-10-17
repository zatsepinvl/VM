using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class Command
    {
        public Action<int> Call { get; set; }
    }
}
