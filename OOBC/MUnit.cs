using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBC
{
   public class MUnit:Unit
    {
       public MUnit() : base("M")
       {
       }

       public override Unit Next { get; }= new CMUnit();

       public override uint NextCount { get; } = 100;
    }
}
