using System;
using System.Collections.Generic;
using System.Text;
using AIBot.Core.Utility;

namespace AIBot.Core.Dto
{
    public class Symptoms
    {
        public string CheckSymptomThere(out Enums.SymptomKind symptomKind)
        {
            symptomKind = Enums.SymptomKind.Mental;
            return "";
        }
        public List<string> GetPhysicalSymptoms()
        {
            return new List<string>()
            {
                "Headaches",
                "Discomfort",
                "Queasy", 
                "Constipated",
                "Diarrhea",
                "Insomnia", 
                "Infections",
                "Sweating",
                "Dizziness",
                "Twitches"
            };
        }

        public List<string> GetMentalSymptoms()
        {
            return new List<string>()
            {
                "Feeling sad",
                "Feeling down",
                "Confused",
                "Dull",
                "Nauseated",
                "Panic",
                "Uneasiness",
                "Nervous",
                "Worrying",
                "Unhappiness",
                "Agitation",
                "Moodiness",
                "Irritability",
                "Overwhelmed",
                "Anger",
                "Loneliness",
                "Isolated",

            };
        }
    }
}
