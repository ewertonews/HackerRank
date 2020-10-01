using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class HttpRequest
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public string ApiUrl { get; set; }

        public async Task<HttpResponseMessage> Get(Dictionary<string, string> query, int page)
        {
            return await Task.Run(() => {
                List<string> queryArgs = new List<string>();
                if (query != null)
                {
                    foreach (var key in query.Keys)
                    {
                        queryArgs.Add($"{key}={query[key]}");
                    }
                }
                string queryArgsString = string.Join("&", queryArgs.ToArray());
                string requestUrl = $"{ApiUrl}?{queryArgsString}&page={page}";
                return httpClient.GetAsync(requestUrl);
            });
        }

        public async Task<HttpResponseMessage> Get(Dictionary<string, string> searchCriteria)
        {
            return await Task.Run(() => {
                List<string> queryArgs = new List<string>();
                if (searchCriteria != null)
                {
                    foreach (var key in searchCriteria.Keys)
                    {
                        queryArgs.Add($"{key}={searchCriteria[key]}");
                    }
                }
                string queryArgsString = string.Join("&", queryArgs.ToArray());
                string requestUrl = $"{ApiUrl}?{queryArgsString}";
                return httpClient.GetAsync(requestUrl);
            });
        }
    }
}
