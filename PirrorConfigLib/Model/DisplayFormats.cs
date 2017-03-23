using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PirrorConfigLib.Enums;

namespace PirrorConfigLib.Model
{
    public class DisplayFormats
    {
        public DisplayFormats(TimeFormat timeFormat, TemperatureUnit temperatureUnits)
        {
            TimeFormat = timeFormat;
            TemperatureUnits = temperatureUnits;
        }

        public TimeFormat TimeFormat { get; }

        public TemperatureUnit TemperatureUnits { get; }
    }
}
