using AngleSharp;
using HLTVClient.Client;
using HLTVClient.Entities;

namespace HLTVClient.Parsers
{
    public class TopParser : IParser<Task<List<Team>>>
    {
        public async Task<List<Team>> ParseAsync(HLTVRequestClient client, string? page)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(page));

            var teamsHolders = document.QuerySelectorAll(".ranked-team");
            var teams = new List<Team>();
            var parser = new TeamParser();

            foreach (var _ in teamsHolders)
            {
                teams.Add(await parser.ParseAsync(client, _.ToHtml()));
            }

            return teams;
        }
    }
}
