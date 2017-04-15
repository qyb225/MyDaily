using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyDaily.Procy.ZhiHuProcy {
    class DailyPage {
        public async static Task<RootObject> GetArticle() {
            var http = new HttpClient();
            string url = "https://news-at.zhihu.com/api/4/stories/latest";
            var response = await http.GetAsync(url);
            while (!response.IsSuccessStatusCode) {
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
    public class Story {
        [DataMember]
        public List<string> images { get; set; }

        [DataMember]
        public int type { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string ga_prefix { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public bool? multipic { get; set; }
    }

    [DataContract]
    public class TopStory {
        [DataMember]
        public string image { get; set; }

        [DataMember]
        public int type { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string ga_prefix { get; set; }

        [DataMember]
        public string title { get; set; }
    }

    [DataContract]
    public class RootObject {
        [DataMember]
        public string date { get; set; }

        [DataMember]
        public List<Story> stories { get; set; }

        [DataMember]
        public List<TopStory> top_stories { get; set; }
    }
}
