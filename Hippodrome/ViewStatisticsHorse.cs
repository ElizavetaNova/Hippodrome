using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ViewStatisticsHorse
    {
        public int HorseNumber { get; set; }
        public string HorseName { get; set; }
        public string HorseColor { get; set; }
        public int HorseAge { get; set; }
        public int RaceNumber { get; set; }
        public DateTime RaceDate { get; set; }
        public int? WinHorseNumber { get; set; }
    }
}
