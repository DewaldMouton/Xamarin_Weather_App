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
    public class ItemDisplay {

        public string FieldName { get; set; }
        public string Value { get; set; }

        public ItemDisplay() {

        }

        public ItemDisplay(string fieldName, string value) {
            this.FieldName = fieldName;
            this.Value = value;
        }

        public override string ToString() {
            return FieldName + " : " + Value;
        }
    }
}