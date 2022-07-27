using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlickrApp.Model;
using Newtonsoft.Json;
using RestSharp;

namespace FlickrApp.Utility
{
    public static class TwitterUtility
    {
        public static async Task<string> GetTweets(string searchWord)
        {

            string apiUrl = $"https://api.twitter.com/2/tweets/search/recent";
            string tweets = string.Empty;
            IRestClient _client = new RestClient(apiUrl);
            _client.BaseUrl = new Uri(apiUrl);
            IRestRequest request = new RestRequest(Method.GET)
                    .AddQueryParameter("query", searchWord)
                    .AddHeader("Authorization", $"Bearer {ConfigurationManager.AppSettings["BearerToken"]}");

            IRestResponse response = await _client.ExecuteAsync(request);
            var tweetsjson = JsonConvert.DeserializeObject<TwitterJSON>(response.Content);
            foreach (var tweet in tweetsjson?.data)
            {
                tweets += tweet.text + "\n";
            }
            return tweets;
        }
    }
}
