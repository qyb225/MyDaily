using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyDaily.Procy.TranslateProcy {
    class TranslateProcy {
        public async static Task<RootObject> GetTranslate(string words) {
            var http = new HttpClient();
            string url = String.Format("http://fanyi.youdao.com/openapi.do?keyfrom=MyDaily&key=1146739795&type=data&doctype=json&version=1.1&q={0}", words);
            var response = await http.GetAsync(url);
            while (!response.IsSuccessStatusCode) {
                url = String.Format("http://fanyi.youdao.com/openapi.do?keyfrom=MyDaily&key=1146739795&type=data&doctype=json&version=1.1&q={0}", words);
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
    public class Basic {
        [DataMember]
        public List<string> explains { get; set; }
    }

    [DataContract] 
    public class Web {
        [DataMember]
        public List<string> value { get; set; }

        [DataMember]
        public string key { get; set; }
    }

    [DataContract]
    public class RootObject {
        [DataMember]
        public List<string> translation { get; set; }

        [DataMember]
        public Basic basic { get; set; }

        [DataMember]
        public string query { get; set; }

        [DataMember]
        public int errorCode { get; set; }

        [DataMember]
        public List<Web> web { get; set; }
    }
}
