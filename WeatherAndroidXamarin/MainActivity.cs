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
        private TextView _temperatureTextView;
        private WeatherService _ws;
        int count = 1;

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
            _temperatureTextView = FindViewById<TextView>(Resource.Id.TemperatureTextView);
            _currentDateTextView.Text = DateTime.Today.ToString("M");

            button.Click += SearchWeather;
        }

        private async void SearchWeather(object sender, EventArgs e)
        {
            var result = await _ws.GetForecastForToday(_editText.Text);
            _temperatureTextView.Text = result.Temperature + "°C";
        }
    }
}

