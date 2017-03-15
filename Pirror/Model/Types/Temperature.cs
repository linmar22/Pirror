using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirror.Model.Types
{
    public class Temperature
    {
        private readonly double _cur;
        private readonly double _low;
        private readonly double _high;
        private readonly string _units;

        public Temperature(double current, double low, double high, string units)
        {
            _cur = current;
            _low = low;
            _high = high;
            _units = units;
        }

        public double Current
        {
            get { return _cur; }
        }

        public double Low
        {
            get { return _low; }
        }

        public double High
        {
            get { return _high; }
        }

        public string Units
        {
            get { return _units; }
        }

        public override string ToString()
        {
            return string.Format("Current: {0}, Low: {1}, High: {2}, Units: {3}", Current, Low, High, Units);
        }
    }
}
