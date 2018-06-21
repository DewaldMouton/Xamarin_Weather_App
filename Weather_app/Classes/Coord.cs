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
    public class Coord {

        public double Lon { get; set; }
        public double Lat { get; set; }

        public override string ToString() {
            return
                "Coord{" +
                "lon = '" + Lon + '\'' +
                ",lat = '" + Lat + '\'' +
                "}";
        }
    }
}