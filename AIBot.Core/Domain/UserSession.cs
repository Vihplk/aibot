using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain
{
    [Table("UserSession")]
    public class UserSession: Entity
    {
        public int UserId { get; protected set; }
        public DateTime DateTime { get; protected set; } = DateTime.UtcNow;
        public decimal AnxietyMarks { get; protected set; } = 0;
        public decimal DepressionMarks { get; protected set; } = 0;
        public decimal StressMarks { get; protected set; } = 0;
        public bool IsSessionComplete { get; protected set; }
        public Guid SessionGuid { get; protected set; }

        #region relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion

        public UserSession CreateSession(int userid)
        {
            UserId = userid;
            DateTime = DateTime.UtcNow;
            IsSessionComplete = false;
            SessionGuid=Guid.Empty;
            return this;
        }

        public void SetResults(decimal anxietyMarks, decimal depressionMarks,decimal stressMarks,Guid sessionGuid)
        {
            AnxietyMarks = anxietyMarks;
            DepressionMarks = depressionMarks;
            StressMarks = stressMarks;
            IsSessionComplete = true;
            SessionGuid = sessionGuid;
        }
    }
}
