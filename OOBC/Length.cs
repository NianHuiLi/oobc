using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBC.Test
{
    public class Length
    {
        private readonly int _value;
        private readonly Unit _unit;

        public Length(int value, Unit unit)
        {
            _value = value;
            _unit = unit;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Length;
            if (other == null)
            {
                return false;
            }

            if (this._unit == other._unit)
            {
                return this._value == other._value;
            }

            return this.GetBasicCount() == other.GetBasicCount() ;
        }

        public override int GetHashCode()
        {
            return _value;
        }

        private long GetBasicCount()
        {
            return this._value * this._unit.GetBasicCount();
        }
    }

}
