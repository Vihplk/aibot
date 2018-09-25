using System.Collections.Generic;
using System.Linq;

namespace AIBot.Core.Dto
{
    public class Symptoms
    {
 
        public static List<string> GetPhysicalSymptoms()
        {
            return (new List<string>()
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
            }).Select(p=>p.ToLower()).ToList();
        }

        public static List<string> GetMentalSymptoms()
        {
            return (new List<string>()
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

            }).Select(p => p.ToLower()).ToList();
        }
    }
}
