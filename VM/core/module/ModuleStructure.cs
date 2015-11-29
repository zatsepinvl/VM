using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    class ModuleStructure
    {
        public const string CODE = ".code";
        public const string FUNCTION = ".function";
        public const string ENTRYPOINT = ".entrypoint";

        public const string STRUCTURE_REGEXP_PATTERN = @"[\ ]+|[\:]";
    }
}
