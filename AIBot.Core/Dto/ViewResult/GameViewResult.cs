 namespace AIBot.Core.Dto.ViewResult
{
    public class GameViewResult
    {
        public string GameType { get; set; }
        public int Attempt { get; set; }
        public int Success { get; set; }
        public int Failed { get; set; }
        public int Percentage { get; set; }
    }
}
