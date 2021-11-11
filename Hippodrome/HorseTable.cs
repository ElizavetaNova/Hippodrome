using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class HorseTable
    {
        public HorseTable()
        {
            BettingTables = new HashSet<BettingTable>();
            MembersRaceTables = new HashSet<MembersRaceTable>();
        }

        public int HorseNumber { get; set; }
        public string HorseName { get; set; }
        public string HorseColor { get; set; }
        public int HorseRideCount { get; set; }
        public int HorseWinCount { get; set; }
        public int HorseAge { get; set; }
        public double? Coefficient { get; set; }

        public virtual ICollection<BettingTable> BettingTables { get; set; }
        public virtual ICollection<MembersRaceTable> MembersRaceTables { get; set; }
    }
}
