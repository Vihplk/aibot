using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AIBot.Core.Dto.Forecast;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Forecast;
using AIBot.Core.Service.Interface;
using AIBot.Core.Utility;
using AIBot.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using unirest_net.http;

namespace AIBot.Controllers
{
    [Route("api")]
    public class ForecastController : BaseController
    {
        private readonly ITimeSeriesService _forecasetService;
        private readonly IQuestionSessionService _questionSessionService;
        public ForecastController(ITimeSeriesService forecasetService, IQuestionSessionService questionSessionService)
        {
            _forecasetService = forecasetService;
            _questionSessionService = questionSessionService;
        }
        [HttpGet,Route("forecast/{forecasttype}/{stresstype}")]
        public async Task<IActionResult> Forecast(string forecasttype,string stressType)
        {
            try
            {
                Enums.StressType stessType = stressType.ToLower().StartsWith("a")
                    ? Enums.StressType.Anxiety
                    : stressType.ToLower().StartsWith("d")
                        ? Enums.StressType.Depression
                        : Enums.StressType.Stress;
                 var result = await _questionSessionService.GetResults(UserId, stessType);
                if (result.Count == 0)
                {
                    return Ok();
                }
                _forecasetService.SetType(forecasttype);
                var forecastResponse = new ForecastingResponse();
                switch (forecasttype)
                {
                    case "naive":
                        forecastResponse = await _forecasetService.Naive(result.ToArray(), 5, 0);
                        break;
                    case "sma":
                        forecastResponse = await _forecasetService.SimpleMovingAverage(result.ToArray(), 5, 3, 0);
                        break;
                    case "wma":
                        forecastResponse = await _forecasetService.WeightedMovingAverage(result.ToArray(), 5, (Decimal)0.05, (Decimal)0.15, (Decimal)0.8);
                        break;
                    case "es":
                        forecastResponse = await _forecasetService.ExponentialSmoothing(result.ToArray(), 5, (Decimal)0.8);
                        break;
                    case "ars":
                        forecastResponse = await _forecasetService.AdaptiveRateSmoothing(result.ToArray(), 5, (Decimal)0.2, (Decimal)0.8);
                        break;
                    default:
                        return BadRequest("invalied argumanet");
                }
                return Ok(forecastResponse);
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
          
        }
    }
}
