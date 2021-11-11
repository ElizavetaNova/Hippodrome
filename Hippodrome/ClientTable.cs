using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class ClientTable
    {
        public ClientTable()
        {
            BettingTables = new HashSet<BettingTable>();
            Users = new HashSet<User>();
        }

        public int ClientId { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
        public string ClientMiddleName { get; set; }
        public int ClientAge { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? AccountMoney { get; set; }
        public int? ClientBetCount { get; set; }
        public int? ClientWinCount { get; set; }
        public decimal? ClientWinSum { get; set; }

        public virtual ICollection<BettingTable> BettingTables { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
