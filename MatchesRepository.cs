using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class MatchesRepository
    {
        private static readonly HttpRequest httpRequest = new HttpRequest();
        public MatchesRepository(string transactionsApiUrl)
        {
            httpRequest.ApiUrl = transactionsApiUrl;
        }

        public async Task<MatchModel> Search(Dictionary<string, string> searchCriteria)
        {
            return await Task.Run(async () =>
            {
                int totalPages = int.MaxValue - 1;
                int currentPage = 1;
                var responseMatch = new MatchModel();
                bool requestSuccessful = false;
                List<MatchData> dataList = new List<MatchData>();
                do
                {
                    HttpResponseMessage requestResponse = await httpRequest.Get(searchCriteria, currentPage);
                    requestSuccessful = requestResponse.IsSuccessStatusCode;
                    if (requestSuccessful)
                    {
                        var responseBody = await requestResponse.Content.ReadAsStringAsync();
                        responseMatch = JsonConvert.DeserializeObject<MatchModel>(responseBody);
                        totalPages = responseMatch.total_pages;
                        dataList.AddRange(responseMatch.data.ToList());
                        currentPage++;
                    }

                } while (requestSuccessful && currentPage <= totalPages);

                responseMatch.data = dataList.ToArray();
                return responseMatch;
            });
        }
    }
}
