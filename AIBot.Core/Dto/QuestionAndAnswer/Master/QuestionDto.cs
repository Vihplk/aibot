 namespace AIBot.Core.Dto.QuestionAndAnswer.Master
{
    public class QuestionDto:BaseDto
    { 
        public string QuestionName { get; set; }
        public int Order { get; set; }
        public bool IsQuestion { get; set; }
    }
}
