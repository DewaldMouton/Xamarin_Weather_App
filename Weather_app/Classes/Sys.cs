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
    public class Sys {

        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int ID { get; set; }
        public int Type { get; set; }
        public double Message { get; set; }

        public override string ToString() {
            return
                "Sys{" +
                "country = '" + Country + '\'' +
                ",sunrise = '" + Sunrise + '\'' +
                ",sunSet = '" + Sunset + '\'' +
                ",id = '" + ID + '\'' +
                ",type = '" + Type + '\'' +
                ",message = '" + Message + '\'' +
                "}";
        }
    }
}