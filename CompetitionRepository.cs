using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class CompetitionRepository
    {
        private static readonly HttpRequest httpRequest = new HttpRequest();
        public CompetitionRepository(string transactionsApiUrl)
        {
            httpRequest.ApiUrl = transactionsApiUrl;
        }

        public async Task<CompetitionModel> Search(Dictionary<string, string> searchCriteria)
        {
            return await Task.Run(async () =>
            {
                var responseMatch = new CompetitionModel();
                bool requestSuccessful = false;
               
                HttpResponseMessage requestResponse = await httpRequest.Get(searchCriteria);
                requestSuccessful = requestResponse.IsSuccessStatusCode;
                if (requestSuccessful)
                {
                    var responseBody = await requestResponse.Content.ReadAsStringAsync();
                    responseMatch = JsonConvert.DeserializeObject<CompetitionModel>(responseBody);
                }
                
                return responseMatch;
            });
        }
    }
}
