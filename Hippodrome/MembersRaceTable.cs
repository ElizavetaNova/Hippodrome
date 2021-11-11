using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class MembersRaceTable
    {
        public int MembersRaceId { get; set; }
        public int RaceNumber { get; set; }
        public int HorseNumber { get; set; }
        public int RiderNumber { get; set; }

        public virtual HorseTable HorseNumberNavigation { get; set; }
        public virtual RaceTable RaceNumberNavigation { get; set; }
        public virtual RiderTable RiderNumberNavigation { get; set; }
    }
}
