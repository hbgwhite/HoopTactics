using System;
using System.Collections.Generic;
using System.Text;

namespace DataHarvester
{
    public class PlayerCategories
    {
        public string PlayerName { get; set; }
        public string PlayerTeam { get; set; }
        public decimal PointRank { get; set; }
        public decimal FieldGoalPercentageRank { get; set; }
        public decimal FreeThrowPercentageRank { get; set; }
        public decimal ThreePointRank { get; set; }
        public decimal ReboundRank { get; set; }
        public decimal AssistRank { get; set; }
        public decimal StealRank { get; set; }
        public decimal BlockRank { get; set; }
        public decimal TurnoverRank { get; set; }
    }
}
