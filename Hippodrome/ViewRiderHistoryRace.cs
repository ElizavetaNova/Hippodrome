using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ViewRiderHistoryRace
    {
        public int RiderId { get; set; }
        public string RiderSurname { get; set; }
        public string RiderName { get; set; }
        public string RiderMiddleName { get; set; }
        public int RaceNumber { get; set; }
        public DateTime RaceDate { get; set; }
        public int HorseNumber { get; set; }
        public int? WinHorseNumber { get; set; }
    }
}
