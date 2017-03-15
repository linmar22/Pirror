using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirror.Model.Types
{
    public class Wind
    {
        private readonly string _description;
        private readonly double _speed;
        private readonly WindDirection _direction;
        

        public Wind(string description, double speed, double directionHeading, string direcitonCode, string directionName)
        {
            _description = description;
            _speed = speed;
            _direction = new WindDirection(directionHeading,direcitonCode,directionName);
        }

        public string Description
        {
            get { return _description; }
        }

        public double Speed
        {
            get { return _speed; }
        }

        public WindDirection Direction
        {
            get { return _direction; }
        }

        public override string ToString()
        {
            return string.Format("Description: {0}, Speed: {1}, Direction: {2}", Description, Speed, Direction);
        }
    }

    public class WindDirection
    {
        private readonly double _directionHeading;
        private readonly string _directionCode;
        private readonly string _directionName;

        public WindDirection(double heading, string code, string name)
        {
            _directionHeading = heading;
            _directionCode = code;
            _directionName = name;
        }

        public double Heading
        {
            get { return _directionHeading; }
        }

        public string Code
        {
            get { return _directionCode; }
        }

        public string Name
        {
            get { return _directionName; }
        }

        public override string ToString()
        {
            return string.Format("Heading: {0}, Code: {1}, Name: {2}", Heading, Code, Name);
        }
    }
}
