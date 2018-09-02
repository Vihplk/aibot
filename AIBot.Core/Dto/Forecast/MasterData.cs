using System;
using System.Collections.Generic;

namespace AIBot.Core.Dto.Forecast
{
    [Serializable]
    public class ForecastingResponse
    {
        public MasterData MasterData { get; set; }
        public List<ForecastList> ForecastList { get; set; }
    }
    [Serializable]
    public class MasterData
    {
        public string Type { get; set; }
        public string MSD { get; set; }
        public string MAD { get; set; }
        public string MPE { get; set; }
        public string MAPE { get; set; }
        public string TS { get; set; }
        public string MSE { get; set; }
    }
    [Serializable]
    public class ForecastList
    {
        public string Instance { get; set; }
        public string Value { get; set; }
        public string Forecast { get; set; }
        public string Error { get; set; }
        public string AbsoluteError { get; set; }
        public string PercentError { get; set; }
        public string AbsolutePercentError { get; set; }
    }

}
