using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Pirror.DataAccessLayer;
using Pirror.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pirror
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Timer _timer;
        private int _weatherTimer = 0;

        private WeatherAccess _wa;
        private GmailAccess _ga;

        private ObservableCollection<WeatherForecast> _forecast = new ObservableCollection<WeatherForecast>(); 
        private ObservableCollection<Email> _emails = new ObservableCollection<Email>();
        private double _lastOpacity = 1.0;

        public MainPage()
        {
            InitializeComponent();
            InitDateTime();
            InitWeather();
            InitMail();
            lv_Forecast.ItemsSource = _forecast;
            lv_Emails.ItemsSource = _emails;
            lv_Emails.ContainerContentChanging += OnEmailListContentChanged;
        }

        private void InitDateTime()
        {
            _timer = new Timer(OnTimerTick, null, 0, 1000);
        }

        private void OnTimerTick(object state)
        {
            UpdateDateTime();
            _weatherTimer++;
//            Debug.WriteLine(_weatherTimer);
            if (_weatherTimer == 60)
            {
                UpdateWeather();
                UpdateMail();
                _weatherTimer = 0;
            }
        }

        private void UpdateDateTime()
        {
            var dt = DateTime.Now;
            var time = dt.ToString("HH:mm:ss");
            var date = dt.ToString("D");

            UpdateTextBlock(tb_Time, time);
            UpdateTextBlock(tb_Date, date);
        }

        private void InitMail()
        {
            _ga = new GmailAccess();
            _ga.CheckMail();
            _ga.MailChecked += OnMailChecked;
        }

        private void UpdateMail()
        {
            lv_Emails.ContainerContentChanging -= OnEmailListContentChanged;
            _ga.CheckMail();
        }

        private void InitWeather()
        {
            _wa = new WeatherAccess();
            _wa.WeatherReceived += WaWeatherReceived;
            _wa.WeatherForecastReceived += WaWeatherForecastReceived;

            UpdateWeather();
        }

        private void UpdateWeather()
        {
            Debug.WriteLine("!!! UpdateWeatherCalled");
            _wa.GetWeatherData();
            _wa.GetWeatherForecast();
        }

        private void WaWeatherReceived(object sender, EventArgs e)
        {
            var args = (WeatherEventArgs) e;
            UpdateTextBlock(tb_currentTemperature,Math.Round(args.Weather.Temperature.Current)+ "°C");
            UpdateCurrentWeatherImage(args.Weather.Icon);
        }

        private void WaWeatherForecastReceived(object sender, EventArgs e)
        {
            var args = (WeatherForecastEventArgs) e;

            var t1 = new Task(async () =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        _forecast.Clear();
                        foreach (var forecast in args.ForecastList)
                        {
                            _forecast.Add(forecast);
                        }
                    });
            });
            t1.Start();
        }

        private void UpdateTextBlock(TextBlock tb, string toWrite)
        {
            var t1 = new Task(async () =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        // Your UI update code goes here!
                        tb.Text = toWrite;
                    });
            });
            t1.Start();
        }

        private void UpdateCurrentWeatherImage(string imagePath)
        {
            var t1 = new Task(async () =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.UriSource = new Uri(this.BaseUri, imagePath);
                        img_weatherSymbol.Source = bitmapImage;
                    });
            });
            t1.Start();
        }

        private void OnMailChecked(object sender, EventArgs e)
        {
            _lastOpacity = 1.0;

            var args = (MailArgs) e;


            var t1 = new Task(async () =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        _emails.Clear();

                        lv_Emails.ContainerContentChanging += OnEmailListContentChanged;

                        foreach (var piMail in args.PiMails)
                        {
                            _emails.Add(piMail);
                        }
                    });
            });
            t1.Start();
        }

        

        private void OnEmailListContentChanged(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            
            if (args.ItemIndex >= 6)
            {
                if (_lastOpacity >= 0.1)
                {
                    _lastOpacity = _lastOpacity - 0.1;
                }
                args.ItemContainer.Opacity = _lastOpacity;
            }
        }


    }
}
