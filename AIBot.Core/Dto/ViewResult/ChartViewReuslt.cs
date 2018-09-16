 using System;

namespace AIBot.Core.Dto.ViewResult
{
    public class ChartViewReuslt
    {
        public int Stress { get; set; }
        public int Depression { get; set; }
        public int Anxiety { get; set; }
        public string Date { get; set; }

        public ChartViewReuslt(decimal stress, decimal depression, decimal anexiety,DateTime date)
        {
            Stress = Convert.ToInt32(stress);
            Depression = Convert.ToInt32(depression);
            Anxiety = Convert.ToInt32(anexiety);
            Date = $"{date.ToShortDateString()}-{date.ToShortTimeString()}";
        }
    }
}
