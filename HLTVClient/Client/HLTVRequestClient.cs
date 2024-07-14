using HLTVClient.Parsers;
using RestSharp;
using System.Globalization;
using System.Text.Json;

namespace HLTVClient.Client
{
    public class HLTVRequestClient
    {
        private RestClient _client;

        private const string TOP_TEAMS = "ranking/teams";

        public HLTVRequestClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
            _client.AddDefaultHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36");
        }

        public async Task GetTopAsync()
        {
            var lastMondayDateString = GetLastMondayDateString();
            var page = await GetPageAsync($"/{TOP_TEAMS}/{lastMondayDateString}");
            var parser = new TopParser();

            Console.WriteLine(JsonSerializer.Serialize(await parser.ParseAsync(this, page)));
        }

        public async Task<string?> GetPageAsync(string url)
        {
            var request = new RestRequest(url);
            var response = await _client.ExecuteGetAsync(request);

            return response.Content;
        }

        private string GetLastMondayDateString()
        {
            DateTime today = DateTime.Today;
            int daysSinceLastMonday = (int)today.DayOfWeek - (int)DayOfWeek.Monday;

            if (daysSinceLastMonday < 0)
            {
                daysSinceLastMonday += 7;
            }

            DateTime lastMonday = today.AddDays(-daysSinceLastMonday);
            
            return lastMonday.ToString("yyyy/MMMM/dd", CultureInfo.InvariantCulture).ToLower();
        }
    }
}
