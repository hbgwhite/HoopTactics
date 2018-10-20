using Newtonsoft.Json;

namespace DataHarvester
{
    [JsonConverter(typeof(PlayerConverter))]
    public class Player
    {
        public int PlayerId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public int GamesPlayed { get; set; }
        public decimal Minutes { get; set; }
        public decimal FieldGoalsMade { get; set; }
        public decimal FieldGoalsAttempted { get; set; }
        public decimal FieldGoalPercentage { get; set; }
        public decimal ThreePointFieldGoalMade { get; set; }
        public decimal ThreePointFieldGoalAttempted { get; set; }
        public decimal ThreePointFieldGoalPercentage { get; set; }
        public decimal FreeThrowMade { get; set; }
        public decimal FreeThrowAttempted { get; set; }
        public decimal FreeThrowPercentage { get; set; }
        public decimal OffensiveRebound { get; set; }
        public decimal DefensiveRebound { get; set; }
        public decimal Rebound { get; set; }
        public decimal Assist { get; set; }
        public decimal Steal { get; set; }
        public decimal Block { get; set; }
        public decimal Turnover { get; set; }
        public decimal PersonalFoul { get; set; }
        public decimal Points { get; set; }
        public decimal Efficiency { get; set; }
    }
}