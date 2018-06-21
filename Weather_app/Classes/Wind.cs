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
    public class Wind {

        public int Deg { get; set; }
        public double Speed { get; set; }

        public override string ToString() {
            return
                "Wind{" +
                "deg = '" + Deg + '\'' +
                ",speed = '" + Speed + '\'' +
                "}";
        }
    }
}