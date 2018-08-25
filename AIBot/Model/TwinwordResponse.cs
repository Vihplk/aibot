using System;

namespace AIBot.Model
{
    [Serializable]
    public class TwinwordResponse
    {
        public int answerid { get; set; }
        public double similarity { get; set; }
        public double value { get; set; }
        public string version { get; set; }
        public string author { get; set; }
        public string email { get; set; }
        public string result_code { get; set; }
        public string result_msg { get; set; }
    }
}
