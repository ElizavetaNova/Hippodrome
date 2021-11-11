using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class BettingTable
    {
        public int BetNumber { get; set; }
        public decimal BetSum { get; set; }
        public int ClientId { get; set; }
        public int BetHorseNumber { get; set; }
        public int BetRaceNumber { get; set; }
        public double? BetCoefficient { get; set; }

        public virtual HorseTable BetHorseNumberNavigation { get; set; }
        public virtual RaceTable BetRaceNumberNavigation { get; set; }
        public virtual ClientTable Client { get; set; }
    }
}
