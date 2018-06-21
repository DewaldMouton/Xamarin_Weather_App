using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Weather_app.Services {

    public class WeatherService {

        private string URL = "http://api.openweathermap.org/data/2.5/weather?q=";
        private string MY_API = "&appid=cfd76b23e06c289ac93f5d12149badf1";

        Classes.Forecast forecast = new Classes.Forecast();
        String cityName;

        public async Task<Classes.Forecast> toForecast(String city) {
            cityName = city;
            await makeRequest(URL + cityName + MY_API);
            Console.WriteLine("Returning", forecast);
            return forecast;
        }

        public async Task makeRequest(string url) {
            Console.WriteLine("In request");
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(new Uri(url));
            request.ContentType = "application/JSON";
            request.Method = "GET";

            using (WebResponse webRequest = await request.GetResponseAsync()) {
                using (Stream stream = webRequest.GetResponseStream()) {
                    using (StreamReader streamReader = new StreamReader(stream)) {
                        forecast = JsonConvert.DeserializeObject<Classes.Forecast>(streamReader.ReadToEnd());
                    }
                }
            }
        }
    }
}