using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirror.Model.Types
{
    public class Clouds
    {
        private readonly int _value;
        private readonly string _name;

        public Clouds(int value, string name)
        {
            _value = value;
            _name = name;
        }

        public int Value
        {
            get { return _value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return string.Format("Value: {0}, Name: {1}", Value, Name);
        }
    }
}
