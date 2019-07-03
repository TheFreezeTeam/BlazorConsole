﻿namespace BlazorCli.Shared.Features.WeatherForecast
{
  using System;
  using System.Collections.Generic;
  using BlazorCli.Shared.Features.Base;

  public class GetWeatherForecastsResponse : BaseResponse
  {
    /// <summary>
    /// a default constructor is required for deserialization
    /// </summary>
    public GetWeatherForecastsResponse() { }

    public GetWeatherForecastsResponse(Guid aRequestId)
    {
      WeatherForecasts = new List<WeatherForecastDto>();
      RequestId = aRequestId;
    }

    public List<WeatherForecastDto> WeatherForecasts { get; set; }
  }
}