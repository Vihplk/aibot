using System.Threading.Tasks;
using AIBot.Core.Dto.Forecast;

namespace AIBot.Core.Service.Interface
{
    public interface ITimeSeriesService
    {
        Task<ForecastingResponse> Naive(decimal[] values, int Extension, int Holdout);
        Task<ForecastingResponse> SimpleMovingAverage(decimal[] values, int Extension, int Periods, int Holdout);
        Task<ForecastingResponse> WeightedMovingAverage(decimal[] values, int Extension, params decimal[] PeriodWeight);
        Task<ForecastingResponse> ExponentialSmoothing(decimal[] values, int Extension, decimal Alpha);
        Task<ForecastingResponse> AdaptiveRateSmoothing(decimal[] values, int Extension, decimal MinGamma,
            decimal MaxGamma);
        void SetType(string type);
    }
}
