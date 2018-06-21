using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Weather_app.Classes;

namespace Weather_app {
    class WeatherListAdapter : BaseAdapter<ItemDisplay> {

        private Context mContext;
        private List<ItemDisplay> mItems;

        public WeatherListAdapter(Context context, List<ItemDisplay> items) {
            mContext = context;
            mItems = items;
        }

        public override int Count {
            get {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override ItemDisplay this[int position] {
            get {
                return mItems[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {

            View row = convertView;

            if (row == null) {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.Adapter_View, parent, false);
            }

            String field = mItems[position].FieldName;
            String value = mItems[position].Value;

            TextView forecastField = row.FindViewById<TextView>(Resource.Id.forecastField);
            TextView forecastValue = row.FindViewById<TextView>(Resource.Id.forecastValue);

            forecastField.Text = field;
            forecastValue.Text = value;

            if (position % 2 == 0) {
                forecastField.SetBackgroundColor(Color.ParseColor("#F2F2F2"));
                forecastValue.SetBackgroundColor(Color.ParseColor("#F2F2F2"));
            }

            if (position == 6) {
                forecastValue.SetTextColor(Color.ParseColor("#fd6601"));
            } else {
                forecastValue.SetTextColor(Color.ParseColor("#000000"));
            }
            return row;

        }
    }
}