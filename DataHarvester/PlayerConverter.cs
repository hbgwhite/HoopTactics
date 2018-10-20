using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataHarvester
{
    public class PlayerConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var player = (Player) value;
            serializer.Serialize(writer, new[]
            {
                player.PlayerId.ToString(),
                player.Rank.ToString(),
                player.Name,
                player.Team,
                player.GamesPlayed.ToString(),
                player.Minutes.ToString(),
                player.FieldGoalsMade.ToString(),
                player.FieldGoalsAttempted.ToString(),
                player.FieldGoalPercentage.ToString(),
                player.ThreePointFieldGoalMade.ToString(),
                player.ThreePointFieldGoalAttempted.ToString(),
                player.ThreePointFieldGoalPercentage.ToString(),
                player.FreeThrowMade.ToString(),
                player.FreeThrowAttempted.ToString(),
                player.FreeThrowPercentage.ToString(),
                player.OffensiveRebound.ToString(),
                player.DefensiveRebound.ToString(),
                player.Rebound.ToString(),
                player.Assist.ToString(),
                player.Steal.ToString(),
                player.Block.ToString(),
                player.Turnover.ToString(),
                player.PersonalFoul.ToString(),
                player.Points.ToString(),
                player.Efficiency.ToString()
            });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            try
            {

                var array = JArray.Load(reader);
                var player = existingValue as Player ?? new Player();
                player.PlayerId = (int) array.ElementAtOrDefault(0);
                player.Rank = (int) array.ElementAtOrDefault(1);
                player.Name = (string) array.ElementAtOrDefault(2);
                player.Team = (string) array.ElementAtOrDefault(3);
                player.GamesPlayed = (int) array.ElementAtOrDefault(4);
                player.Minutes = (decimal) array.ElementAtOrDefault(5);
                player.FieldGoalsMade = (decimal) array.ElementAtOrDefault(6);
                player.FieldGoalsAttempted = (decimal) array.ElementAtOrDefault(7);
                player.FieldGoalPercentage = (decimal) array.ElementAtOrDefault(8);
                player.ThreePointFieldGoalMade = (decimal) array.ElementAtOrDefault(9);
                player.ThreePointFieldGoalAttempted = (decimal) array.ElementAtOrDefault(10);
                player.ThreePointFieldGoalPercentage = (decimal) array.ElementAtOrDefault(11);
                player.FreeThrowMade = (decimal) array.ElementAtOrDefault(12);
                player.FreeThrowAttempted = (decimal) array.ElementAtOrDefault(13);
                player.FreeThrowPercentage = (decimal) array.ElementAtOrDefault(14);
                player.OffensiveRebound = (decimal) array.ElementAtOrDefault(15);
                player.DefensiveRebound = (decimal) array.ElementAtOrDefault(16);
                player.Rebound = (decimal) array.ElementAtOrDefault(17);
                player.Assist = (decimal) array.ElementAtOrDefault(18);
                player.Steal = (decimal) array.ElementAtOrDefault(19);
                player.Block = (decimal) array.ElementAtOrDefault(20);
                player.Turnover = (decimal) array.ElementAtOrDefault(21);
                player.PersonalFoul = (decimal) array.ElementAtOrDefault(22);
                player.Points = (decimal) array.ElementAtOrDefault(23);
                //player.Efficiency = (decimal) array.ElementAtOrDefault(24);

                return player;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Player);
        }
    }
}