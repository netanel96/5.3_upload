using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static wpf_MVVM_EntityFramework.Model.AdressToCoordinateApi;

namespace wpf_MVVM_EntityFramework.ViewModel
{
    class GeoCoordinateAdressTOCoordinateApi
    {
        /********     PRIVATE API  FOR Google Adress to Coourdinate service    **********/
        public const string API_KEY = "AIzaSyDiSEvb5lEtA1qouymyM29eUJ3Fz-o3HZk";
        // public const string BASE_URL = "https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY";
        public const string BASE_URL = "https://maps.googleapis.com/maps/api/geocode/json?address={1}&key={0}";
        
        /*************צורת מימוש ********/
        //private async void GetGeoCoordinate(string address)
        //{
        //    var Coordinate = await ViewModels.GeoCoordinateApi.GetGeoCoordinateAsync(address);
        //    double let = Coordinate.results[0].geometry.location.lat;
        //    double lng = Coordinate.results[0].geometry.location.lng;
        //}

        public static async Task<GeoCoordinate> GetGeoCoordinateAsync(string address)
        {
            GeoCoordinate result = new GeoCoordinate();

            string url = string.Format(BASE_URL, API_KEY, address);

            using (HttpClient client = new HttpClient())
            {

                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<GeoCoordinate>(json);
            }

            return result;

        }
    }
}
