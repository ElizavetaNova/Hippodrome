using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ViewBetClientHistory
    {
        public int ClientId { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
        public string ClientMiddleName { get; set; }
        public int AccountNumber { get; set; }
        public string BetNumber { get; set; }
        public decimal BetSum { get; set; }
        public int BetHorseNumber { get; set; }
        public int BetRaceNumber { get; set; }
        public double? BetCoefficient { get; set; }
        public int? WinHorseNumber { get; set; }
    }
}
