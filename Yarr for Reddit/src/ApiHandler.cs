using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yarn;
using Yarr_for_Reddit.src.model;
using Newtonsoft.Json;
using System.Web;

namespace Yarr_for_Reddit.src
{
    class ApiHandler
    {
        public Rootobject sub = new Rootobject();

        public async Task<Rootobject> GetApiData(string subredditName)
        {
            string subredditUrl = "https://www.reddit.com/r/" + subredditName + ".json";
            SubredditModel subreddit = new SubredditModel();
            HttpClient httpclient = new HttpClient();
            var response = await httpclient.GetStringAsync(subredditUrl);
            sub = JsonConvert.DeserializeObject<Rootobject>(response);
            Console.WriteLine(sub.data.children[0].data.title);
            return await Task.FromResult(sub);
        }

    }
}
