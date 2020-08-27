using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Yarn.Models;

namespace Yarn.Controllers
{
    class Subreddit
    {
        public string urlToJson(string url)
        {
            //using (WebClient wc = new WebClient())
            //{
            //    var json = wc.DownloadString(url);
            //}
            var jsonString = new WebClient().DownloadString("url");

            return jsonString;
        }

        public void jsonToModel(string jsonString)
        {
            subreddit oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<subreddit>(jsonString);
        }

        // url to ... realese?
        public void test(string url)
        {
            var client = new RestClient(url); 
            IRestResponse response = client.Execute(new RestRequest()); 
            var releases = JArray.Parse(response.Content);
        }

        public class Release
        {
            [DeserializeAs(Name = "name")]
            public string Name {get; set;}
            [DeserializeAs(Name = "published_at")]
            public string PublishedAt {get; set;}
        }



    }
}
