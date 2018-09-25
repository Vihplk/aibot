using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIBot.Core.Dto;
using AIBot.Core.Utility;
namespace AIBot.Core
{
    public class Soundex
    {

        public static Dictionary<Enums.SymptomKind,List<string>> MatchingWord(string sentence)
        {
            var words = sentence.ToLower().Split(' ');
            var mwords = new List<string>();
            var pwords = new List<string>();
            foreach (var item in words)
            {
                if (Symptoms.GetMentalSymptoms().Contains(item))
                {
                    mwords.Add(item);
                    continue;
                }
                if (Symptoms.GetPhysicalSymptoms().Contains(item))
                {
                    pwords.Add(item);
                }
            }

            return new Dictionary<Enums.SymptomKind, List<string>>()
            {
                {
                    Enums.SymptomKind.Mental, mwords
                },
                {
                    Enums.SymptomKind.Physical, pwords
                },

            };
        }

        //  ABCDEFGHIJKLMNOPQRSTUVWXYZ
        private const string _values = "01230120022455012623010202";
        private const int EncodingLength = 4;
         
        public static string Encode(string text)
        {
            char prevChar = ' ';

            text = Normalize(text);
            if (text.Length == 0)
                return text;

            StringBuilder builder = new StringBuilder();
            builder.Append(text[0]);
            for (int i = 1;
                i < text.Length && builder.Length < EncodingLength;
                i++)
            {

                char c = _values[text[i] - 'A'];

                if (c != '0' && c != prevChar)
                {
                    builder.Append(c);
                    prevChar = c;
                }
            }


            while (builder.Length < EncodingLength)
                builder.Append('0');


            return builder.ToString();
        }

        protected static string Normalize(string text)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                    builder.Append(Char.ToUpper(c));
            }
            return builder.ToString();
        }
    }
}
