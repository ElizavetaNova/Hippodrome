using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class RiderTable
    {
        public RiderTable()
        {
            MembersRaceTables = new HashSet<MembersRaceTable>();
        }

        public int RiderId { get; set; }
        public string RiderSurname { get; set; }
        public string RiderName { get; set; }
        public string RiderMiddleName { get; set; }
        public string Master { get; set; }
        public int RiderAge { get; set; }

        public virtual ICollection<MembersRaceTable> MembersRaceTables { get; set; }
    }
}
