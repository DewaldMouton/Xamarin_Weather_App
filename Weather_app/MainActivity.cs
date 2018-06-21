using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System;

namespace Weather_app {
    [Activity(Label = "Open Weather", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : Activity {

        EditText editText;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            editText = FindViewById<EditText>(Resource.Id.editText);
            Button getWeather = FindViewById<Button>(Resource.Id.button);

            getWeather.Click += (s, e) => DisplayWeather();

            string cityName = GetCityName();

            if (cityName != null || GetCityName() != "null") {
                editText.Text = cityName;
            }
        }

        public void DisplayWeather() {
            editText = FindViewById<EditText>(Resource.Id.editText);
            Intent intent = new Intent(this, typeof(WeatherDetail));
            string cityName = editText.Text;
 
            if (cityName.Trim().Equals("") || cityName.Length > 20) {
                Toast.MakeText(ApplicationContext, "Please enter a valid city name.", ToastLength.Long).Show();
            } else {
                StoreCityName(cityName);
                intent.PutExtra("City", cityName);
                StartActivity(intent);
            }
        }

        private void StoreCityName(string cityName) {
            ISharedPreferences mSharedPreference = GetSharedPreferences("CityName", FileCreationMode.Private); //PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor mEditor = mSharedPreference.Edit();
            mEditor.PutString("CityName", cityName);
            mEditor.Apply();
        }

        private string GetCityName() {
            ISharedPreferences mSharedPreference = GetSharedPreferences("CityName", FileCreationMode.Private);
            string previousCity = mSharedPreference.GetString("CityName", null);
            return previousCity;
        }
    }
}