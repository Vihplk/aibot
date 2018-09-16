using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain
{
    [Table("UserSessionGame")]
    public class UserSessionGame : Entity
    {
        public Guid SessionId { get; set; }
        public int GameId { get; set; }
        public int Success { get; set; }
        public int Failed { get; set; }
    }
}
