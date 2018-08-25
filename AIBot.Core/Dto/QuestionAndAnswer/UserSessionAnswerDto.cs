namespace AIBot.Core.Dto.QuestionAndAnswer
{
    public class UserSessionAnswerDto : BaseDto
    {
        public int Id { get; set; }
        public string Question { get; set; } 
        public string UserAnswer { get; set; }
        public int Value { get; set; }
        public string Summery { get; set; }

        public UserSessionAnswerDto(int id,string question,string userAnswer,int value,string summery)
        {
            Id = id;
            Question = question;
            UserAnswer = userAnswer;
            Value = value;
            Summery = summery;
        }
    }
}
