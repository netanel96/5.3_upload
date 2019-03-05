using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static BL.functions.ApiAdressToCoordinate;

namespace BL.functions
{
    public class ApiAdressToCoordinate
    {

        public class GeoCoordinate
        {
            public IList<Result> results { get; set; }
            public string status { get; set; }
        }

        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public IList<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Result
        {
            public IList<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public IList<string> types { get; set; }


        }



        /********     PRIVATE API  FOR Google Adress to Coourdinate service    **********/
        public const string API_KEY = "AIzaSyDiSEvb5lEtA1qouymyM29eUJ3Fz-o3HZk";
        // public const string BASE_URL = "https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY";
        public const string BASE_URL = "https://maps.googleapis.com/maps/api/geocode/json?address={1}&key={0}";

        /************* מימוש ********/
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
