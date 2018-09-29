 namespace AIBot.Core
{
    public class GlobalConfig
    {
        public const string Key = "janson is the best";
        public const string Issuer = "http://localhost:65000";
        public const string Audience = "http://localhost:65000";

        public const string ConnectionString =
<<<<<<< HEAD
            @"Data Source=VIHPLK1;Initial Catalog=MindHealer;Integrated Security=True";
=======
            @"Data Source=DESKTOP-RQBOHL0\SQLEXPRESS;Initial Catalog=mindhealer;Integrated Security=True";
>>>>>>> 7d804f4f87e146f8d94e47f0c1e3724a3fb9db38

        public const string TwaipKey = "sQIrQkX7LMIF5tWf3ItVzFmjL2l3v4Zpk/k+s2cT5hjHO4BE38CSDEY5koPc1X/ImohAJYsP0uacuiTRdJVCPw==";
        public const string TwaipApiEndpoint = "https://api.twinword.com/api/v6/text/similarity/";

        public static int[] QuestionLandingBoundIndex = new[] {1, 8};
        public static int QuestionEndIndex = 13;
        public static int TotalQuestions = 6;
        public static double DefaultChatTreshold = 0.2;
        public static dynamic Claims = new
        {
            Email = "email",
            UserId = "userid",
            Name = "name"
        };
    }
}
