using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AIBot.Core.Utility
{
    public class Enums
    {
        public enum StressType
        {
            Anxiety = 1,
            Depression = 2,
            Stress = 3
        }

        public enum QuestionType
        {
            Landing=1,
            Question = 2,
            Random = 3,
            Over = 4
        }

        public enum Game
        {
            StressOne,
            StressTwo,
            StresThree,
            Anx,
            Dep
        }
    }
}
