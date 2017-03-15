using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirror.Model.Types
{
    public class Humidity
    {
        private int _value;
        private string _units;

        public Humidity(int value, string units)
        {
            _value = value;
            _units = units;
        }

        public int Value
        {
            get { return _value; }
        }

        public string Units
        {
            get { return _units; }
        }

        public override string ToString()
        {
            return string.Format("Value: {0}, Units: {1}", Value, Units);
        }
    }
}
