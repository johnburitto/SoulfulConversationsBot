using AngleSharp;
using HLTVClient.Client;
using HLTVClient.Entities;
using System.Globalization;

namespace HLTVClient.Parsers
{
    public class TeamParser : IParser<Task<Team>>
    {
        public async Task<Team> ParseAsync(HLTVRequestClient client, string? page)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(page));

            // Data
            var name = document.QuerySelector(".name")?.TextContent;
            var logo = document.QuerySelector(".team-logo")?.QuerySelector("img")?.GetAttribute("src");
            var points = document.QuerySelector(".points")?.TextContent.Replace("(", "").Replace(")", "").Replace("points", "").Trim();
            var rank = document.QuerySelector(".position")?.TextContent;

            // Detail Data
            var detailInfoPage = await client.GetPageAsync(document.QuerySelector(".moreLink")?.GetAttribute("href")!);
            
            document.Close();
            document = await context.OpenAsync(req => req.Content(detailInfoPage));

            var teamStats = document.QuerySelectorAll(".profile-team-stat");
            var country = document.QuerySelector(".team-country")?.ChildNodes[1].TextContent.Trim();
            var flag = document.QuerySelector(".team-country")?.QuerySelector("img")?.GetAttribute("src");
            var weeksInTop30 = int.Parse(teamStats[1].QuerySelector("span")?.TextContent ?? "0");
            var averagePlayerAge = float.Parse(teamStats[2].QuerySelector("span")?.TextContent ?? "0", CultureInfo.InvariantCulture);

            return new()
            {
                Name = name,
                LogoThumbnails = logo,
                Rank = rank,
                Points = int.Parse(points ?? "0"),
                Country = country,
                FlagThumbnails = flag,
                WeeeksInTop30 = weeksInTop30,
                AveragePlayerAge = averagePlayerAge
            };
        }
    }
}
