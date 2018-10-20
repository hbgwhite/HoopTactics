using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataHarvester
{
    internal class Program
    {

        private static readonly HttpClient httpClient = new HttpClient();
        public static void Main(string[] args)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DoStuff().Wait();
        }

        static async Task DoStuff()
        {
            var response = await httpClient.GetAsync(
                "https://stats.nba.com/stats/leagueLeaders?LeagueID=00&PerMode=PerGame&Scope=S&Season=2017-18&SeasonType=Regular+Season&StatCategory=PTS");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NbaStatResponse>(json);
                var players = result.ResultSet.Players;

                var pointsAverage = players.Select(x => x.Points).Average();
                var pointsStandardDeviation = CalculateStandardDeviation(players.Select(x => x.Points));

                var reboundAverage = players.Select(x => x.Rebound).Average();
                var reboundStandardDeviation = CalculateStandardDeviation(players.Select(x => x.Rebound));

                var stealAverage = players.Select(x => x.Steal).Average();
                var stealStandardDeviation = CalculateStandardDeviation(players.Select(x => x.Steal));

                var blockAverage = players.Select(x => x.Block).Average();
                var blockStandardDeviation = CalculateStandardDeviation(players.Select(x => x.Block));

                var fieldGoalPercentageAverage = players.Select(x => x.FieldGoalPercentage * x.FieldGoalsAttempted).Average();
                var fieldGoalStandardDeviation = CalculateStandardDeviation(players.Select(x => x.FieldGoalPercentage * x.FieldGoalsAttempted));

                var freeThrowPercentageAverage = players.Select(x => x.FreeThrowPercentage * x.FreeThrowAttempted).Average();
                var freeThrowPercentageStandardDeviation = CalculateStandardDeviation(players.Select(x => x.FreeThrowPercentage * x.FreeThrowAttempted));

                var threePointerAverage = players.Select(x => x.ThreePointFieldGoalMade).Average();
                var threePointerStandardDeviation = CalculateStandardDeviation(players.Select(x => x.ThreePointFieldGoalMade));

                var turnoverAverage = players.Select(x => x.Turnover).Average();
                var turnoverStandardDeviation = CalculateStandardDeviation(players.Select(x => x.Turnover));

                var assistAverage = players.Select(x => x.Assist).Average();
                var assistStandardDeviation = CalculateStandardDeviation(players.Select(x => x.Assist));

                var playerCategories = players.Select(x => new PlayerCategories
                {
                    PlayerName = x.Name,
                    PlayerTeam = x.Team,
                    AssistRank = Math.Round((x.Assist - assistAverage) / assistStandardDeviation, 2),
                    StealRank = Math.Round((x.Steal - stealAverage) / stealStandardDeviation, 2),
                    ReboundRank = Math.Round((x.Rebound - reboundAverage) / reboundStandardDeviation, 2),
                    FieldGoalPercentageRank =
                        Math.Round((x.FieldGoalPercentage * x.FieldGoalsAttempted - fieldGoalPercentageAverage) / fieldGoalStandardDeviation,
                            2),
                    FreeThrowPercentageRank =
                        Math.Round(
                            (x.FreeThrowPercentage * x.FreeThrowAttempted - freeThrowPercentageAverage) / freeThrowPercentageStandardDeviation,
                            2),
                    BlockRank = Math.Round((x.Block - blockAverage) / blockStandardDeviation, 2),
                    ThreePointRank =
                        Math.Round((x.ThreePointFieldGoalMade - threePointerAverage) / threePointerStandardDeviation,
                            2),
                    TurnoverRank = Math.Round((x.Turnover - turnoverAverage) / turnoverStandardDeviation, 2),
                    PointRank = Math.Round((x.Points - pointsAverage) / pointsStandardDeviation, 2)
                });

                var playerRank = playerCategories.OrderByDescending(x =>
                    x.AssistRank + x.BlockRank + x.StealRank + x.ReboundRank + x.PointRank + x.ThreePointRank +
                    x.FieldGoalPercentageRank + x.FreeThrowPercentageRank - x.TurnoverRank);

                var i = 1;
                playerRank.ToList().ForEach(x => Console.WriteLine($"Rank: {i++} \t Sum: {x.AssistRank + x.BlockRank + x.StealRank + x.ReboundRank + x.PointRank + x.ThreePointRank + x.FieldGoalPercentageRank + x.FreeThrowPercentageRank - x.TurnoverRank}\t"
                + $" AST: {x.AssistRank}\t BLK: {x.BlockRank}\t STL: {x.StealRank}\t PTS: {x.PointRank}\t 3PT: {x.ThreePointRank}\t FG%: {x.FieldGoalPercentageRank}\t FT%: {x.FreeThrowPercentageRank}\t REB: {x.ReboundRank}\t TO: {x.TurnoverRank*-1}\t Team: {x.PlayerTeam}\t Name: {x.PlayerName}"));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Shit.");
            }

        }



        private static decimal CalculateStandardDeviation(IEnumerable<decimal> values)
        {
            var average = values.Average();
            var sum = (decimal) values.Sum(d => Math.Pow((double) d - (double) average, 2));
            var result = (decimal) Math.Sqrt(((double)sum / (values.Count() - 1)));
            return result;
        }
    }
}
