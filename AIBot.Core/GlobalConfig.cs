﻿ namespace AIBot.Core
{
    public class GlobalConfig
    {
        public const string Key = "janson is the best";
        public const string Issuer = "http://localhost:65000";
        public const string Audience = "http://localhost:65000";

        public const string ConnectionString =
            "Data Source=DESKTOP-LE44UH9;Initial Catalog=AIBot;Integrated Security=True";

        public const string TwaipKey = "sQIrQkX7LMIF5tWf3ItVzFmjL2l3v4Zpk/k+s2cT5hjHO4BE38CSDEY5koPc1X/ImohAJYsP0uacuiTRdJVCPw==";
        public const string TwaipApiEndpoint = "https://api.twinword.com/api/v6/text/similarity/";

        public static int[] QuestionLandingBoundIndex = new[] {1, 7};
        public static int QuestionEndIndex = 14;
        public static dynamic Claims = new
        {
            Email = "email",
            UserId = "userid",
            Name = "name"
        };
    }
}
