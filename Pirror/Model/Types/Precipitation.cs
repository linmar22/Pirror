using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirror.Model.Types
{
    public class Precipitation
    {
        private readonly int _value;
        private readonly string _mode;

        public Precipitation(int valueInMilimeters, string mode)
        {
            _value = valueInMilimeters;
            _mode = mode;
        }

        public int Value
        {
            get { return _value; }
        }

        public string Mode
        {
            get { return _mode; }
        }

        public override string ToString()
        {
            return string.Format("Value: {0}, Mode: {1}", Value, Mode);
        }
    }
}
