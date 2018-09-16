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
        public int Index { get; set; }
        public bool IsQuestion()
        {
            if (Index <= GlobalConfig.QuestionLandingBoundIndex[1])
            {
                return false;
            }

            return true;
        }

        public bool IsQuestionOver()
        {
            return Index > GlobalConfig.QuestionEndIndex;
        }
    }
}
