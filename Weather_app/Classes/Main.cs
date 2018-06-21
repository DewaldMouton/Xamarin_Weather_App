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

    public class Main {

        public double Temp { get; set; }
        public double TempMin { get; set; }
        public int Humidity { get; set; }
        public double Pressure { get; set; }
        public double TempMax { get; set; }

        public override string ToString() {
            return
                "Main{" +
                "temp = '" + Temp + '\'' +
                ",temp_min = '" + TempMin + '\'' +
                ",humidity = '" + Humidity + '\'' +
                ",pressure = '" + Pressure + '\'' +
                ",temp_max = '" + TempMax + '\'' +
                "}";
        }
    }
}