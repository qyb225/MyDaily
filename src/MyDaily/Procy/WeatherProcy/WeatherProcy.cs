using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyDaily.Procy.WeatherProcy {
    class WeatherProcy {
        public async static Task<RootObject> GetWeather(string city) {
            var http = new HttpClient();
            string url = String.Format("https://api.seniverse.com/v3/weather/daily.json?key=yvltitg0l5idrrnn&location={0}&language=zh-Hans&unit=c&start=0&days=5", city);
            var response = await http.GetAsync(url);
            while (!response.IsSuccessStatusCode) {
                url = String.Format("https://api.seniverse.com/v3/weather/daily.json?key=yvltitg0l5idrrnn&location={0}&language=zh-Hans&unit=c&start=0&days=5", "Guangzhou");
                response = await http.GetAsync(url);
            }
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }

    [DataContract]
    public class Location {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public string path { get; set; }

        [DataMember]
        public string timezone { get; set; }

        [DataMember]
        public string timezone_offset { get; set; }
    }

    [DataContract]
    public class Daily {
        [DataMember]
        public string date { get; set; }

        [DataMember]
        public string text_day { get; set; }

        [DataMember]
        public string code_day { get; set; }

        [DataMember]
        public string text_night { get; set; }

        [DataMember]
        public string code_night { get; set; }

        [DataMember]
        public string high { get; set; }

        [DataMember]
        public string low { get; set; }

        [DataMember]
        public string precip { get; set; }

        [DataMember]
        public string wind_direction { get; set; }

        [DataMember]
        public string wind_direction_degree { get; set; }

        [DataMember]
        public string wind_speed { get; set; }

        [DataMember]
        public string wind_scale { get; set; }
    }

    [DataContract]
    public class Result {
        [DataMember]
        public Location location { get; set; }

        [DataMember]
        public List<Daily> daily { get; set; }

        [DataMember]
        public string last_update { get; set; }
    }

    [DataContract]
    public class RootObject {
        [DataMember]
        public List<Result> results { get; set; }
    }
}
