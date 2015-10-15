using System;
using Android.App;
using Android.OS;
using Android.Widget;
using WeatherAndroidXamarin.Service.Weather;

namespace WeatherAndroidXamarin
{
    [Activity(Label = "WeatherAndroidXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView _currentDateTextView;
        private EditText _editText;
        private TextView _humidityTextView;
        private TextView _humidityTheDayAfterAfterTomorrowTextView;
        private TextView _humidityTheDayAfterTomorrowTextView;
        private TextView _humidityTomorrowTextView;
        private TextView _temperatureTextView;
        private TextView _temperatureTheDayAfterAfterTomorrowTextView;
        private TextView _temperatureTheDayAfterTomorrowTextView;
        private TextView _temperatureTomorrowTextView;
        private TextView _theDayAfterAfterTomorrowDateTextView;
        private TextView _theDayAfterTomorrowDateTextView;
        private TextView _tomorrowDateTextView;
        private WeatherService _ws;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _ws = new WeatherService();
            var now = DateTime.Now;


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);
            _editText = FindViewById<EditText>(Resource.Id.EditText);

            _currentDateTextView = FindViewById<TextView>(Resource.Id.CurrentDateTextView);
            _tomorrowDateTextView = FindViewById<TextView>(Resource.Id.TomorrowDateTextView);
            _theDayAfterTomorrowDateTextView = FindViewById<TextView>(Resource.Id.DayAfterTomorrowDateTextView);
            _theDayAfterAfterTomorrowDateTextView = FindViewById<TextView>(Resource.Id.DayAfterAfterTomorrowDateTextView);

            _temperatureTextView = FindViewById<TextView>(Resource.Id.TemperatureTextView);
            _temperatureTomorrowTextView = FindViewById<TextView>(Resource.Id.TemperatureTomorrowTextView);
            _temperatureTheDayAfterTomorrowTextView = FindViewById<TextView>(Resource.Id.TemperatureTheDayAfterTomorrowTextView);
            _temperatureTheDayAfterAfterTomorrowTextView = FindViewById<TextView>(Resource.Id.TemperatureTheDayAfterAfterTomorrowTextView);

            _humidityTextView = FindViewById<TextView>(Resource.Id.HumidityTextView);
            _humidityTomorrowTextView = FindViewById<TextView>(Resource.Id.HumidityTomorrowTextView);
            _humidityTheDayAfterTomorrowTextView = FindViewById<TextView>(Resource.Id.HumidityTheDayAfterTomorrowTextView);
            _humidityTheDayAfterAfterTomorrowTextView = FindViewById<TextView>(Resource.Id.HumidityTheDayAfterAfterTomorrowTextView);


            _currentDateTextView.Text = DateTime.Today.ToString("M");
            _tomorrowDateTextView.Text = now.AddDays(1).ToString("dd-MM-yy");
            _theDayAfterTomorrowDateTextView.Text = now.AddDays(2).ToString("dd-MM-yy");
            _theDayAfterAfterTomorrowDateTextView.Text = now.AddDays(3).ToString("dd-MM-yy");


            button.Click += SearchWeather;
        }

        private async void SearchWeather(object sender, EventArgs e)
        {
            var result = await _ws.GetForecastForToday(_editText.Text);
            _temperatureTextView.Text = result.Temperature + "°C";
            _humidityTextView.Text = result.Humidity + "%";

            var tomorrow = await _ws.GetForecastForTomorrow(_editText.Text);
            _temperatureTomorrowTextView.Text = tomorrow.Temperature + "°C";
            _humidityTomorrowTextView.Text = tomorrow.Humidity + "%";

            var theDayAfterTomorrow = await _ws.GetForecastForTheDayAfterTomorrow(_editText.Text);
            _temperatureTheDayAfterTomorrowTextView.Text = theDayAfterTomorrow.Temperature + "°C";
            _humidityTheDayAfterTomorrowTextView.Text = theDayAfterTomorrow.Humidity + "%";

            var theDayAfterAfterTomorrow = await _ws.GetForecastForTheDayAfterAfterTomorrow(_editText.Text);
            _temperatureTheDayAfterAfterTomorrowTextView.Text = theDayAfterAfterTomorrow.Temperature + "°C";
            _humidityTheDayAfterAfterTomorrowTextView.Text = theDayAfterAfterTomorrow.Humidity + "%";

        }
    }
}

