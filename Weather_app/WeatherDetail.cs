using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Weather_app {
    [Activity(Label = "Open Weather", Theme = "@style/AppTheme")]
    public class WeatherDetail : Activity {

        Classes.Forecast forecast = new Classes.Forecast();
        Services.WeatherService getForecast = new Services.WeatherService();
        List<Classes.ItemDisplay> weatherList = new List<Classes.ItemDisplay>();
        ImageView icon;
        String searchedCityName = "";

        protected async override void OnCreate(Bundle savedInstanceState) {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Weather_Detail);

            ProgressBar loader = FindViewById<ProgressBar>(Resource.Id.loader);
            DateTime time = (new DateTime(1970, 1, 1, 2, 0, 0)).AddMilliseconds((double)forecast.DT * 1000L);
            searchedCityName = Intent.GetStringExtra("City");
            TextView cityName = FindViewById<TextView>(Resource.Id.cityName);
            TextView tempDeg = FindViewById<TextView>(Resource.Id.tempDeg);
            TextView condition = FindViewById<TextView>(Resource.Id.condition);
            TextView updated = FindViewById<TextView>(Resource.Id.updated);
            View line = FindViewById<View>(Resource.Id.view);
            icon = FindViewById<ImageView>(Resource.Id.weatherIcon);

            while (true) {
                loader.Visibility = ViewStates.Visible;

                forecast = await getForecast.toForecast(searchedCityName);

                if (forecast.Name != null) {
                    cityName.Text = ("Weather in " + forecast.Name + ", " + forecast.Sys.Country);
                    String iconURL = "http://openweathermap.org/img/w/" + forecast.Weather[0].Icon + ".png";
                    var imageBitmap = GetImageFromUrl(iconURL);
                    icon.SetImageBitmap(imageBitmap);

                    tempDeg.Text = ((forecast.Main.Temp - 273.15) + " °C");
                    condition.Text = ((forecast.Weather[0].Description.Substring(0, 1).ToUpper()) + forecast.Weather[0].Description.Substring(1, forecast.Weather[0].Description.Length - 1) + "");
                    updated.Text = ("Last updated: " + string.Format("{0:g}", time));

                    //Populating list view start
                    ListView myListView = FindViewById<ListView>(Resource.Id.listView);
                    WeatherListAdapter weatherListAdapter = new WeatherListAdapter(this, PopulateList(forecast));
                    myListView.Adapter = weatherListAdapter;
                    loader.Visibility = ViewStates.Invisible;
                    cityName.Visibility = ViewStates.Visible;
                    tempDeg.Visibility = ViewStates.Visible;
                    condition.Visibility = ViewStates.Visible;
                    updated.Visibility = ViewStates.Visible;
                    line.Visibility = ViewStates.Visible;
                    break;
                }
            }
        }

        /*
         * Get image icon image from url
         * @Param string url
         */
        private Bitmap GetImageFromUrl(string url) {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient()) {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }

        private List<Classes.ItemDisplay> PopulateList(Classes.Forecast forecast) {
            DateTime unix;
            weatherList.Add(new Classes.ItemDisplay("Wind", CalculateWindSpeed(forecast.Wind.Speed) + "\n" + CalculateWindDirection(forecast.Wind.Deg)));
            weatherList.Add(new Classes.ItemDisplay("Cloudiness", (forecast.Weather[0].Description.Substring(0, 1).ToUpper()) + forecast.Weather[0].Description.Substring(1, forecast.Weather[0].Description.Length - 1) + ""));
            weatherList.Add(new Classes.ItemDisplay("Pressure", forecast.Main.Pressure + " hpa"));
            weatherList.Add(new Classes.ItemDisplay("Humidity", forecast.Main.Humidity + " %"));
            unix = (new DateTime(1970, 1, 1)).AddMilliseconds((double)forecast.Sys.Sunrise * 1000L);
            weatherList.Add(new Classes.ItemDisplay("Sunrise", string.Format("{0:t}", unix)));
            unix = (new DateTime(1970, 1, 1)).AddMilliseconds((double)forecast.Sys.Sunset * 1000L);
            weatherList.Add(new Classes.ItemDisplay("Sunset", string.Format("{0:t}", unix)));
            weatherList.Add(new Classes.ItemDisplay("Geo Coords", "[ " + forecast.Coord.Lat + ", " + forecast.Coord.Lon + " ]"));
            return weatherList;
        }

        private string CalculateWindSpeed(double windSpeed) {
            string windRating = "";

            if (windSpeed < 0.3) {
                windRating = "Calm";
            } else if (windSpeed >= 0.3 && windSpeed < 1.6) {
                windRating = "Light Air";
            } else if (windSpeed >= 1.6 && windSpeed < 3.4) {
                windRating = "Light Breeze";
            } else if (windSpeed >= 3.4 && windSpeed < 5.5) {
                windRating = "Gentle Breeze";
            } else if (windSpeed >= 5.5 && windSpeed < 8) {
                windRating = "Moderate Breeze";
            } else if (windSpeed >= 8 && windSpeed < 10.8) {
                windRating = "Fresh Breeze";
            } else if (windSpeed >= 10.8 && windSpeed < 13.9) {
                windRating = "Strong Breeze";
            } else if (windSpeed >= 13.9 && windSpeed < 17.2) {
                windRating = "High Wind";
            } else if (windSpeed >= 17.2 && windSpeed < 20.8) {
                windRating = "Gale";
            } else if (windSpeed >= 20.8 && windSpeed < 24.5) {
                windRating = "Severe Gale";
            } else if (windSpeed >= 24.5 && windSpeed < 28.5) {
                windRating = "Storm";
            } else if (windSpeed >= 28.5 && windSpeed < 32.7) {
                windRating = "Violent Storm";
            } else if (windSpeed >= 32.7) {
                windRating = "Hurricane Force";
            }
            return windRating + " " + windSpeed + " m/s";
        }

        private string CalculateWindDirection(double windDeg) {
            string windDirection = "";

            if (windDeg == 0 || windDeg == 360) {
                windDirection = "North";
            } else if (windDeg > 0 && windDeg < 45) {
                windDirection = "North North-East";
            } else if (windDeg == 45) {
                windDirection = "North-East";
            } else if (windDeg > 45 && windDeg < 90) {
                windDirection = "East North-East";
            } else if (windDeg == 90) {
                windDirection = "East";
            } else if (windDeg > 90 && windDeg < 135) {
                windDirection = "East South-East";
            } else if (windDeg == 135) {
                windDirection = "South-East";
            } else if (windDeg > 135 && windDeg < 180) {
                windDirection = "South South-East";
            } else if (windDeg == 180) {
                windDirection = "South";
            } else if (windDeg > 180 && windDeg < 225) {
                windDirection = "South South-West";
            } else if (windDeg == 225) {
                windDirection = "South-West";
            } else if (windDeg > 225 && windDeg < 270) {
                windDirection = "West South-West";
            } else if (windDeg == 270) {
                windDirection = "West";
            } else if (windDeg > 270 && windDeg < 315) {
                windDirection = "West North-West";
            } else if (windDeg == 315) {
                windDirection = "North-West";
            } else if (windDeg > 315 && windDeg < 360) {
                windDirection = "West North-West";
            }
            return windDirection + " ( " + windDeg + " )";
        }
    }
}