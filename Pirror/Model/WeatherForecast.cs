using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Pirror.Model.Enums;
using Pirror.Model.Types;

namespace Pirror.Model
{
    public class WeatherForecast
    {
        private DateTime _date;
        private string _dayOfWeekShort;
        private string _tempDayNight;
        private string _imagePath;

        public WeatherForecast(DateTime date, string dayOfWeekShort, string tempDayNight, string imageCode)
        {
            _date = date;
            _dayOfWeekShort = dayOfWeekShort;
            _tempDayNight = tempDayNight;
            _imagePath = ResolveImagePath(imageCode);
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public string DayOfWeekShort
        {
            get { return _dayOfWeekShort; }
        }

        public string TempDayNight
        {
            get { return _tempDayNight; }
        }

        public string ImagePath
        {
            get { return _imagePath; }
        }

        public override string ToString()
        {
            return string.Format("Date: {0}, DayOfWeekShort: {1}, TempDayNight: {2}, ImagePath: {3}", Date, DayOfWeekShort, TempDayNight, ImagePath);
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
                Debug.WriteLine("!!! WeatherForecast.ResolveImagePath Could not find image for {imageCode}");
                return "Assets/na.png";
            }

            

        }
    }
}