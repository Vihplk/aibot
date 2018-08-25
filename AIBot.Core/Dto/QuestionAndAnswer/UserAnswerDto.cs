namespace AIBot.Core.Dto.QuestionAndAnswer
{
    public class UserAnswerDto : BaseDto
    {
        public int SessionId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerName { get; set; }
        public int Value { get; set; } = 0;
        public string MatchingPercentageSummary { get; set; }
        public int MatchingAnswerId { get; set; }
        public bool IsQuestion()
        {
            return QuestionId > 7;
        }

        public bool IsQuestionOver()
        {
            return QuestionId >= 31;
        }
    }
}
