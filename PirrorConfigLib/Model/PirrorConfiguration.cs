using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PirrorConfigLib.Enums;

namespace PirrorConfigLib.Model
{
    public class PirrorConfiguration
    {
        private readonly Location _location;
        private readonly SensorSettings _sensorSettings;
        private readonly EmailCredentials _emailCredentials;
        private readonly DisplayFormats _displayFormats;

        private PirrorConfiguration()
        {
            //For the serializer
        }

        public PirrorConfiguration(Location location, SensorSettings sensorSettings, EmailCredentials emailCredentials, DisplayFormats displayFormats)
        {
            _location = location;
            _sensorSettings = sensorSettings;
            _emailCredentials = emailCredentials;
            _displayFormats = displayFormats;
        }

        public static PirrorConfiguration GetSampleConfiguration()
        {
            var loc = new Location("Denmark","Copenhagen");
            var sensor = new SensorSettings(ScreenActivationType.CloseRange);
            var emailCreds = new EmailCredentials("linas.martusevicius@gmail.com","spaikas");
            var displayFormats = new DisplayFormats(TimeFormat.TwentyFourHourWithSeconds, TemperatureUnit.Celcius);

            var toReturn = new PirrorConfiguration(loc,sensor,emailCreds,displayFormats);

            return toReturn;
        }

        public string GetAsXmlString()
        {
            var serializer = new XmlSerializer(this.GetType());
            var toReturn = string.Empty;

            using (var stringWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, this);
                    toReturn = stringWriter.ToString();
                }
            }
            return toReturn;
        }

        public Location Location
        {
            get { return _location; }
        }

        public SensorSettings SensorSettings
        {
            get { return _sensorSettings; }
        }

        public EmailCredentials EmailCredentials
        {
            get { return _emailCredentials; }
        }

        public DisplayFormats DisplayFormats
        {
            get { return _displayFormats; }
        }
    }
}
