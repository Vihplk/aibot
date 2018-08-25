using System;

namespace AIBot.Core.Dto.QuestionAndAnswer
{
    public class UserSessionDto:BaseDto
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public decimal Marks { get; set; }
    }
}
