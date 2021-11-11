using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class RaceTable
    {
        public RaceTable()
        {
            BettingTables = new HashSet<BettingTable>();
            MembersRaceTables = new HashSet<MembersRaceTable>();
        }

        public int RaceNumber { get; set; }
        public DateTime RaceDate { get; set; }
        public int? WinHorseNumber { get; set; }
        public TimeSpan? RaceDuration { get; set; }

        public virtual ICollection<BettingTable> BettingTables { get; set; }
        public virtual ICollection<MembersRaceTable> MembersRaceTables { get; set; }
    }
}
