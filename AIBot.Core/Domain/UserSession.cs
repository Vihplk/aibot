using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain
{
    [Table("UserSession")]
    public class UserSession: Entity
    {
        public int UserId { get; protected set; }
        public DateTime DateTime { get; protected set; } = DateTime.UtcNow;
        public decimal Marks { get; protected set; }
        public bool IsSessionComplete { get; protected set; }

        #region relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion

        public UserSession CreateSession(int userid)
        {
            UserId = userid;
            DateTime = DateTime.UtcNow;
            Marks = 0;
            IsSessionComplete = false;
            return this;
        }
    }
}
