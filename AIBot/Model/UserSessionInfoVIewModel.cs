namespace AIBot.Model
{
    public class UserSessionInfoViewModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string MatchingAnswer { get; set; }
        public int Value { get; set; }
        public string Summary { get; set; }
    }
}
