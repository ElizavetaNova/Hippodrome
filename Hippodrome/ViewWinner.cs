using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ViewWinner
    {
        public int RaceNumber { get; set; }
        public int? WinHorseNumber { get; set; }
        public TimeSpan? RaceDuration { get; set; }
        public string HorseName { get; set; }
        public string HorseColor { get; set; }
        public int HorseWinCount { get; set; }
        public int HorseAge { get; set; }
        public string RiderSurname { get; set; }
        public string RiderName { get; set; }
        public string RiderMiddleName { get; set; }
    }
}
