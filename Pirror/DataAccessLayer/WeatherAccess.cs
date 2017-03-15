using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Pirror.Model;

namespace Pirror.DataAccessLayer
{
    class WeatherAccess
    {
        public WeatherAccess()
        {
            
        }

        public void GetWeatherData()
        {

            var client = new HttpClient();
            var url = @"http://api.openweathermap.org/data/2.5/weather?q=Copenhagen&mode=xml&units=metric&APPID=94c53ead81e81e4d5040c6fff0eb08e2";

            Weather toReturn = null;

            var t1 = new Task(async () =>
            {
                var response = await client.GetAsync(url);
                var resString = response.Content.ReadAsStringAsync();

                toReturn = new Weather(resString.Result);
//                Debug.WriteLine(toReturn.ToString());
                OnWeatherDataReceived(new WeatherEventArgs(toReturn));
            });
            t1.Start();
        }

        public void GetWeatherForecast()
        {
            var client = new HttpClient();
            var url = @"http://api.openweathermap.org/data/2.5/forecast/daily?q=Copenhagen&mode=xml&units=metric&cnt=7&APPID=94c53ead81e81e4d5040c6fff0eb08e2";

            List<WeatherForecast> toReturn = null;

            var t1 = new Task(async () =>
            {
                var response = await client.GetAsync(url);
                var resString = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var xDoc = XDocument.Parse(resString.Result);
                    toReturn = ProcessWeatherForecastResponse(xDoc);
                }
                OnWeatherForecastDataReceived(new WeatherForecastEventArgs(toReturn));
            });
            t1.Start();
        }

        private List<WeatherForecast> ProcessWeatherForecastResponse(XDocument xDoc)
        {
            var toReturn = new List<WeatherForecast>();

            var forecastElement = FindFirstElement(xDoc, "forecast");

            var individualDays = FindAllInElement(forecastElement, "time");

            foreach (var dayElement in individualDays)
            {
                var date = DateTime.Parse(dayElement.Attribute("day").Value);

                var tempNode = FindFirstDecendantInElement(dayElement, "temperature");
                var tempDay = Math.Round(double.Parse(tempNode.Attribute("day").Value));
                var tempNight = Math.Round(double.Parse(tempNode.Attribute("night").Value));

                var symbolNode = FindFirstDecendantInElement(dayElement, "symbol");

                var dayOfWeekShort = date.ToString("ddd");
                var symbolString = symbolNode.Attribute("var").Value;
                var dayNightTemp = tempDay + "°C / " + tempNight + "°C";

                var toAdd = new WeatherForecast(date, dayOfWeekShort, dayNightTemp, symbolString);
//                Debug.WriteLine(toAdd);
                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        private List<XElement> FindAllElements(XDocument xDoc, string elementName)
        {
            var query = from c in xDoc.Descendants(elementName) select c;

            return query.ToList();
        }

        private List<XElement> FindAllInElement(XElement searchElement, string elementName)
        {
            var query = from c in searchElement.Descendants(elementName) select c;

            return query.ToList();
        }

        private XElement FindFirstDecendantInElement(XElement searchElement, string toFind)
        {
            var query = from c in searchElement.Descendants(toFind) select c;

            return query.First();
        }

        private XElement FindFirstElement(XDocument xDoc, string elementName)
        {
            var query = from c in xDoc.Descendants(elementName) select c;

            return query.First();
        }

        // Event object
        public event EventHandler WeatherReceived;

        // Event raiser
        protected virtual void OnWeatherDataReceived(WeatherEventArgs e)
        {
            this.WeatherReceived?.Invoke(this, e);

        }

        public event EventHandler WeatherForecastReceived;

        protected virtual void OnWeatherForecastDataReceived(WeatherForecastEventArgs e)
        {
            this.WeatherForecastReceived?.Invoke(this,e);
        }
    }

public class WeatherEventArgs : EventArgs
{
    private readonly Weather _weather;

    public WeatherEventArgs(Weather weather)
    {
        _weather = weather;
    }

    public Weather Weather
    {
        get { return _weather; }
    }
}

    public class WeatherForecastEventArgs : EventArgs
    {
        private readonly List<WeatherForecast> _list;

        public WeatherForecastEventArgs(List<WeatherForecast> list)
        {
            _list = list;
        }

        public List<WeatherForecast> ForecastList
        {
            get { return _list; }
        }
    }
}
