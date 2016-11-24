using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBC
{
    public class CMUnit : Unit
    {
        public CMUnit() : base("CM") { }

        public override Unit Next { get; } = new MMUnit();

        public override uint NextCount { get; } = 10;
    }
}
