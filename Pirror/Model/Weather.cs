using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pirror.Model.Enums;
using Pirror.Model.Types;

namespace Pirror.Model
{
    public class Weather
    {
        private WeatherCode _code;
        private string _value;
        private DateTime _lastUpdate;

        private DateTime _sunrise;
        private DateTime _sunset;
        private Temperature _temperature;
        private Wind _wind;
        private Humidity _humidity;
        private Pressure _pressure;
        private Clouds _clouds;
        private int _visibilityMeters;
        private Precipitation _precipitation;
        private string _icon;

        public WeatherCode WeatherCode
        {
            get { return _code; }
            set { _code = value; }
        }

        public string WeatherName
        {
            get { return _value; }
            set { _value = value; }
        }

        public DateTime Sunrise
        {
            get { return _sunrise; }
            set { _sunrise = value; }
        }

        public DateTime Sunset
        {
            get { return _sunset; }
            set { _sunset = value; }
        }

        public Wind Wind
        {
            get { return _wind; }
            set { _wind = value; }
        }

        public Humidity Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }

        public Pressure Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }

        public Clouds Clouds
        {
            get { return _clouds; }
            set { _clouds = value; }
        }

        public int VisibilityMeters
        {
            get { return _visibilityMeters; }
            set { _visibilityMeters = value; }
        }

        public Precipitation Precipitation
        {
            get { return _precipitation; }
            set { _precipitation = value; }
        }

        public Temperature Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public Weather(string XmlData)
        {

            ProcessXmlToWeatherObject(XmlData);
        }

        private void ProcessXmlToWeatherObject(string xmlData)
        {
//            Debug.WriteLine(xmlData.ToString());
            var xDoc = XDocument.Parse(xmlData);

            var sunNode = FindFirstElement(xDoc, "sun");
            var sunRise = DateTime.Parse(sunNode.Attribute("rise").Value);
            var sunSet = DateTime.Parse(sunNode.Attribute("set").Value);

            _sunrise = sunRise;
            _sunset = sunSet;
//            Debug.WriteLine(_sunrise);
//            Debug.WriteLine(_sunset);

            var temperatureNode = FindFirstElement(xDoc, "temperature");
            var temperatureValue = double.Parse(temperatureNode.Attribute("value").Value);
            var temperatureMin = double.Parse(temperatureNode.Attribute("min").Value);
            var temperatureMax = double.Parse(temperatureNode.Attribute("max").Value);
            var temperatureUnits = temperatureNode.Attribute("unit").Value;

            _temperature = new Temperature(temperatureValue,temperatureMin,temperatureMax,temperatureUnits);

//            Debug.WriteLine(_temperature);

            var humidityNode = FindFirstElement(xDoc, "humidity");
            var humidityVal = int.Parse(humidityNode.Attribute("value").Value);
            var humidityUnits = humidityNode.Attribute("unit").Value;

            _humidity = new Humidity(humidityVal,humidityUnits);
//            Debug.WriteLine(_humidity);

            var pressureNode = FindFirstElement(xDoc, "pressure");
            var pressureVal = double.Parse(pressureNode.Attribute("value").Value);
            var pressureUnits = pressureNode.Attribute("unit").Value;

            _pressure = new Pressure(pressureVal, pressureUnits);
//            Debug.WriteLine(_pressure);

            var windNode = FindFirstElement(xDoc, "wind");
            var windSpeedNode = windNode.Descendants("speed").First();
            var windSpeedVal = double.Parse(windSpeedNode.Attribute("value").Value);
            var windSpeedName = windSpeedNode.Attribute("name").Value;
            var windDirectionNode = windNode.Descendants("direction").First();
            var windDirectionVal = double.Parse(windDirectionNode.Attribute("value").Value);
            var windDirectionCode = windDirectionNode.Attribute("code").Value;
            var windDirectionName = windDirectionNode.Attribute("name").Value;

            _wind = new Wind(windSpeedName,windSpeedVal,windDirectionVal,windDirectionCode,windDirectionName);
//            Debug.WriteLine(_wind);

            var cloudsNode = FindFirstElement(xDoc, "clouds");
            var cloudsVal = int.Parse(cloudsNode.Attribute("value").Value);
            var cloudsName = cloudsNode.Attribute("name").Value;

            _clouds = new Clouds(cloudsVal, cloudsName);
//            Debug.WriteLine(_clouds);


            var visibilityNode = FindFirstElement(xDoc,"visibility");
            var fromVisNode = visibilityNode.Attribute("value");
            var visibilityVal = 0;
            if (fromVisNode != null)
            {
                visibilityVal = int.Parse(fromVisNode.Value);
            }
            _visibilityMeters = visibilityVal;
//            Debug.WriteLine(_visibilityMeters);

            var precipitationNode = FindFirstElement(xDoc, "precipitation");
            var precipitationMode = precipitationNode.Attribute("mode").Value;
            var precipitationVal = 0;
            if (precipitationMode != "no")
            {
                precipitationVal = int.Parse(precipitationNode.Attribute("value").Value);
            }

            _precipitation = new Precipitation(precipitationVal,precipitationMode);
//            Debug.WriteLine(_precipitation);

            var weatherNode = FindFirstElement(xDoc,"weather");
            var weatherNumber = (WeatherCode)int.Parse(weatherNode.Attribute("number").Value);
            var weatherValue = weatherNode.Attribute("value").Value;
            var weatherIcon = weatherNode.Attribute("icon").Value;

            _code = weatherNumber;
            _value = weatherValue;
            _icon = ResolveImagePath(weatherIcon);

//            Debug.WriteLine(_code);
//            Debug.WriteLine(_value);

            var lastUpdateNode = FindFirstElement(xDoc, "lastupdate");
            var lastUpdateValue = DateTime.Parse(lastUpdateNode.Attribute("value").Value);

            _lastUpdate = lastUpdateValue;

//            Debug.WriteLine(_lastUpdate);

        }

        private string ResolveImagePath(string imageCode)
        {
            var expectedPath = "Assets/" + imageCode + ".png";
            if (File.Exists(expectedPath))
            {
                return expectedPath;
            }
            else
            {
                Debug.WriteLine("!!! Weather.ResolveImagePath Could not find image for " + imageCode);
                return "Assets/na.png";
            }
            

        }

        private XElement FindFirstElement(XDocument xDoc, string elementName)
        {
            var query = from c in xDoc.Descendants(elementName) select c;

            return query.First();
        }

        public override string ToString()
        {
            return string.Format("WeatherCode: {0},\nWeatherName: {1},\nSunrise: {2},\nSunset: {3},\nWind: {4},\nHumidity: {5},\nPressure: {6},\nClouds: {7},\nVisibilityMeters: {8}, \nPrecipitation: {9},\nLastUpdate: {10}, \nTemperature: {11}", WeatherCode, WeatherName, Sunrise, Sunset, Wind, Humidity, Pressure, Clouds, VisibilityMeters, Precipitation, LastUpdate, Temperature);
        }
    }
}
