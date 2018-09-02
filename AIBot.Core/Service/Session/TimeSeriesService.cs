using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AIBot.Core.Dto.Forecast;
using AIBot.Core.Forecast;
using AIBot.Core.Service.Interface;

namespace AIBot.Core.Service.Session
{
    public class TimeSeriesService : ITimeSeriesService
    {
        private TimeSeries _ts;
        private string _type = string.Empty;
        public TimeSeriesService()
        {
            _ts = new TimeSeries();
        }

        public void SetType(string type)
        {
            _type = type;
        }

        public async Task<ForecastingResponse> AdaptiveRateSmoothing(decimal[] values, int Extension, decimal MinGamma, decimal MaxGamma)
        {
            return MasterResult(_ts.adaptiveRateSmoothing(values, Extension, MinGamma, MaxGamma));
        }

        public async Task<ForecastingResponse> ExponentialSmoothing(decimal[] values, int Extension, decimal Alpha)
        {
            return MasterResult(_ts.exponentialSmoothing(values, Extension, Alpha));
        }

        public async Task<ForecastingResponse> Naive(decimal[] values, int Extension, int Holdout)
        {
            return MasterResult(_ts.naive(values, Extension, Holdout));
        }

        public async Task<ForecastingResponse> SimpleMovingAverage(decimal[] values, int Extension, int Periods, int Holdout)
        {
            return MasterResult(_ts.simpleMovingAverage(values, Extension, Periods, Holdout));
        }

        public async Task<ForecastingResponse> WeightedMovingAverage(decimal[] values, int Extension, params decimal[] PeriodWeight)
        {
            return MasterResult(_ts.weightedMovingAverage(values, Extension, PeriodWeight));
        }

        ForecastingResponse MasterResult(ForecastTable table)
        {
            return new ForecastingResponse
            {
                MasterData = new MasterData
                {
                    MSD = _ts.MeanSignedError(table, false, TimeSeries.DEFAULT_IGNORE).ToString(),
                    MAD = _ts.MeanAbsoluteError(table, false, TimeSeries.DEFAULT_IGNORE).ToString(),
                    MAPE = _ts.MeanAbsolutePercentError(table, false, TimeSeries.DEFAULT_IGNORE).ToString(),
                    MPE = _ts.MeanPercentError(table, false, TimeSeries.DEFAULT_IGNORE).ToString(),
                    MSE = _ts.MeanSquaredError(table, false, TimeSeries.DEFAULT_IGNORE, 0).ToString(),
                    TS = _ts.TrackingSignal(table, false, TimeSeries.DEFAULT_IGNORE).ToString(),
                    Type = _type
                },
                ForecastList = ConvertTableToResponse(table)
            };
        }

        List<ForecastList> ConvertTableToResponse(ForecastTable request)
        {
            var result = new List<ForecastList>();
            foreach (DataRow item in request.Rows)
            {
                result.Add(new ForecastList
                {
                    Instance = Convert.ToString(item.ItemArray[0]),
                    Value = Convert.ToString(item.ItemArray[1]),
                    Forecast = Convert.ToString(item.ItemArray[2]),
                    Error = Convert.ToString(item.ItemArray[4]),
                    AbsoluteError = Convert.ToString(item.ItemArray[5]),
                    PercentError = Convert.ToString(item.ItemArray[6]),
                    AbsolutePercentError = Convert.ToString(item.ItemArray[7])
                });
            }

            return result;
        }
    }
}
