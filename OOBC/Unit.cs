using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBC
{
    public abstract class Unit
    {
        public string Label { get; }

        protected Unit(string label)
        {
            Label = label;
        }

        public abstract Unit Next { get; }

        public abstract uint NextCount { get; }

        public uint GetBasicCount()
        {
            var nextUnit = this.Next;
            var basicCount = this.NextCount;
            while (nextUnit != null)
            {
                basicCount = basicCount * nextUnit.NextCount;
                nextUnit = nextUnit.Next;
            }
            return basicCount;
        }

        public override bool Equals(object obj)
        {
            return this.Label == (obj as Unit)?.Label;
        }
    }
}
