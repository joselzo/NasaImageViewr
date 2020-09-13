using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaInfoViewer.Models
{
    public class imageDaily
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class MyArray
        {
            [JsonProperty("copyright")]
            public string copyright { get; set; }
            [JsonProperty("date")]
            public string date { get; set; }
            [JsonProperty("explanation")]
            public string explanation { get; set; }
            [JsonProperty("hdurl")]
            public string hdurl { get; set; }
            [JsonProperty("media_type")]
            public string media_type { get; set; }
            [JsonProperty("service_version")]
            public string service_version { get; set; }
            [JsonProperty("title")]
            public string title { get; set; }
            [JsonProperty("url")]
            public string url { get; set; }
        }

        public class Root
        {
            public List<MyArray> MyArray { get; set; }
        }


    }
}
