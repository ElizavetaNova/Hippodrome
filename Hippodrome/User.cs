using System;
using System.Collections.Generic;

#nullable disable

namespace Hippodrome
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int? ClientId { get; set; }

        public virtual ClientTable Client { get; set; }
    }
}
