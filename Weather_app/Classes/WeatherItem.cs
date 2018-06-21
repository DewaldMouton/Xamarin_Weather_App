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
    public class WeatherItem {

        public string Icon { get; set; }
        public string Description { get; set; }
        public string Main { get; set; }
        public int ID { get; set; }

        public override string ToString() {
            return
                    "WeatherItem{" +
                            "icon = '" + Icon + '\'' +
                            ",description = '" + Description + '\'' +
                            ",main = '" + Main + '\'' +
                            ",id = '" + ID + '\'' +
                            "}";
        }

    }
}