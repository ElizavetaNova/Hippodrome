using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ViewInfoMember
    {
        public int RaceNumber { get; set; }
        public DateTime RaceDate { get; set; }
        public int HorseNumber { get; set; }
        public string HorseName { get; set; }
        public double? Coefficient { get; set; }
        public int RiderNumber { get; set; }
        public string RiderSurname { get; set; }
        public string RiderName { get; set; }
        public string RiderMiddleName { get; set; }
        public string Master { get; set; }
    }
}
