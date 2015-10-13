using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherAndroidXamarin.Models
{
    public class Forecast
    {
        public double Temperature { get; set; }
        public int Humidity { get; set; }
    }
}