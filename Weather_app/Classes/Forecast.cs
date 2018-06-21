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

namespace Weather_app.Classes {
    public class Forecast {

        public int DT { get; set; }
        public Coord Coord { get; set; }
        public int Visibility { get; set; }
        public List<WeatherItem> Weather { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
        public Main Main { get; set; }
        public Clouds Clouds { get; set; }
        public int ID { get; set; }
        public Sys Sys { get; set; }
        public string WeatherBase { get; set; }
        public Wind Wind { get; set; }


        public override string ToString() {
            return
                "Response{" +
                "dt = '" + DT + '\'' +
                ",coord = '" + Coord + '\'' +
                ",visibility = '" + Visibility + '\'' +
                ",weather = '" + Weather + '\'' +
                ",name = '" + Name + '\'' +
                ",cod = '" + Cod + '\'' +
                ",main = '" + Main + '\'' +
                ",clouds = '" + Clouds + '\'' +
                ",id = '" + ID + '\'' +
                ",sys = '" + Sys + '\'' +
                ",base = '" + WeatherBase + '\'' +
                ",wind = '" + Wind + '\'' +
                "}";
        }
    }
}