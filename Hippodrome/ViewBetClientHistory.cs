using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ViewBetClientHistory
    {
        public int ClientId { get; set; }
        public int BetNumber { get; set; }
        public int BetRaceNumber { get; set; }
        public DateTime RaceDate { get; set; }
        public int BetHorseNumber { get; set; }
        public decimal BetSum { get; set; }
        public double? BetCoefficient { get; set; }
        public int? WinHorseNumber { get; set; }
    }
}
